
class Account {

    pay(amountToPay) {
        if (this.canPay(amountToPay)) {
            console.log(`Paid ${amountToPay} using ${this.name}`)
        } else if (this.successor) {
            console.log(`Cannot pay using ${this.name}.`)
            this.successor.pay(amountToPay)
        } else {
            console.log('Node of the accounts have enough balance')
        }
    }

    setNext(account) {
        this.successor = account
        return account
    }

    canPay(amount) {
        return this.balance >= amount
    }
}

class Bank extends Account {
    constructor(balance) {
        super()
        this.name = 'Bank'
        this.balance = balance
    }
}

class Paypal extends Account {
    constructor(balance) {
        super()
        this.name = 'Paypal'
        this.balance = balance
    }
}

class Bitcoin extends Account {
    constructor(balance) {
        super()
        this.name = 'Bitcoin'
        this.balance = balance
    }
}


const bank = new Bank(100)
const paypal = new Paypal(200)
const bitcoin = new Bitcoin(300)

bank
    .setNext(paypal)
    .setNext(bitcoin)

bank.pay(300)