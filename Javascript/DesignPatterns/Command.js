/*Real world example

A generic example would be you ordering a food at restaurant. 
You (i.e. Client) ask the waiter (i.e. Invoker) to bring some 
food (i.e. Command) and waiter simply forwards the request to 
Chef (i.e. Receiver) who has the knowledge of what and how to 
cook. Another example would be you (i.e. Client) switching on 
(i.e. Command) the television (i.e. Receiver) using a remote 
control (Invoker).
*/

class Light {
    turnOn() {
        console.log('Light has been lit')
    }

    turnOff() {
        console.log('Darkness')
    }
}

class TurnOnCommand {
    constructor(light) {
        this.light = light
    }

    execute() {
        this.light.turnOn()
    }
}

class TurnOffCommand {
    constructor(light) {
        this.light = light
    }

    execute() {
        this.light.turnOff()
    }
}

class Button {
    constructor(command) {
        this.command = command
    }

    click(){
        this.command.execute()
    }
}

class LightSwitch {
    constructor(buttonUp, buttonDown) {
        this.switched = false
        this.buttonUp = buttonUp
        this.buttonDown = buttonDown
    }

    toggle(){
        const button = this.switched ? this.buttonUp : this.buttonDown

        button.click()

        this.switched = !this.switched
    }
}

const light = new Light()
const turnOff = new TurnOffCommand(light)
const turnOn = new TurnOnCommand(light)

const buttonUp = new Button(turnOff)
const buttonDown = new Button(turnOn)

const lightSwitch = new LightSwitch(buttonUp, buttonDown)

lightSwitch.toggle()
lightSwitch.toggle()
lightSwitch.toggle()
lightSwitch.toggle()

