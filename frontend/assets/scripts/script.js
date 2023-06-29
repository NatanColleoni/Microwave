const form = document.getElementById("form")

let interval = null
let remainingTime = 0

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

form.addEventListener('submit', (event) => {
    event.preventDefault()
    if(interval !== null) clearInterval(interval)

    //TODO: REFAZER NO BACK
    remainingTime = event.target.time.value //?? 1
    let power = event.target.power.value //?? 10
    
    //TODO: REFAZER NO BACK
    if(remainingTime > 120 || remainingTime <= 0){
        alert("Tempo deve estar entre 1 e 120 (1 segundo à 2 minutos)")
    }

    startTimer()
})

