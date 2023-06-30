const form = document.getElementById("form")

let interval = null
let remainingTime = 0
let power = '10'
let isPaused = true

let timer = {
    minutes: document.querySelector('.timer-part-minutes'),
    seconds: document.querySelector('.timer-part-seconds')
}

const updateInterface = () => {
    const minutes = Math.floor(remainingTime / 60)
    const seconds = remainingTime % 60
    
    timer.minutes.textContent = minutes.toString().padStart(2, "0")
    timer.seconds.textContent = seconds.toString().padStart(2, "0")
    
}

const startTimer = () => {
    if(remainingTime === 0) return;
    
    interval = setInterval(() => {
        remainingTime--
        updateInterface()

        if(remainingTime === 0) {
            clearInterval(interval)
        }
    }, 1000);
    
}

const validateMicrowaveSettings = async (setting) => {

    var httpConfig = {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        mode: 'cors',
        body: JSON.stringify(setting)
    }

    var response = await fetch('http://localhost:5184/api/Microwave', httpConfig)
    
    return await response.json()

}


form.addEventListener('submit', async (event) => {
    event.preventDefault()
    const powerElement = document.getElementById("power")
    clearInterval(interval)

    if(event.target.time.value){
        remainingTime = event.target.time.value
    }else {
        remainingTime += 30
    }

    if(event.target.power.value){
        power = event.target.power.value
    }

    powerElement.value = Number(power)

    let microwaveCurrentSetting = {
        power: Number(power),
        time: Number(remainingTime)
    }
    
    var validatedMicrowaveSettings = await validateMicrowaveSettings(microwaveCurrentSetting)

    if(validatedMicrowaveSettings.success) {
        var isValidSettings = validatedMicrowaveSettings.data.isValidSetting

        if(isValidSettings) {
            startTimer()
        } 
    }else {
        var errorListElement = document.getElementById("errorList") 
        var ul = document.createElement("ul")
        errorListElement.appendChild(ul)
        
        for(var i of validatedMicrowaveSettings.data){
            var li = document.createElement("li")
            li.innerText = `${i.key}: ${i.message}`
            ul.appendChild(li)
        }

        setTimeout(()=>{
            ul.classList.add("d-none")
        },10000)
        remainingTime = 0
        timer.seconds.innerText = "00"
        timer.minutes.innerText = "00"
    }
     
})

let heatingProgram = [
    {
        name: "Pipoca",
        alimento: "Pipoca (de micro-ondas)",
        tempo: 180,
        potencia: 7,
        instrucoes: "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento."
    },
    {
        name: "Leite",
        alimento: "Leite",
        tempo: 300,
        potencia: 5,
        instrucoes: " Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras."
    },
    {
        name: "Carnes de boi",
        alimento: "Carne em pedaço ou fatias",
        tempo: 840,
        potencia: 4,
        instrucoes: "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."
    },
    {
        name: "Frango",
        alimento: "Frango (qualquer corte)",
        tempo: 480,
        potencia: 7,
        instrucoes: "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme"
    },
    {
        name: "Feijão",
        alimento: "Feijão congelado",
        tempo: 480,
        potencia: 9,
        instrucoes: "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas."
    }
]