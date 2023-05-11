type Ticket = { seat:int; customer:string}

// value is changeable
let mutable tickets = [for n in 1..10 -> {seat = n; customer = ""}]

//This creates a dispalyticket function which allows the system to display the specific seat number as well as the name of customer next to it

let DisplayTicket () = 
    printfn "%-5s %-15s" "Number of seat" "Name of customer" //prints seat and name of customer
    printfn "%-5s %-15s" "__________---_---_____-________--" // this shows how the system should display the information
    for ticket in tickets do 
    printfn "   %-5d    %-15s" ticket.seat ticket.customer

//Order seat function
let OrderSeat (customers:string, seats:int) = 
    let assignCustomer (ticket:Ticket) = //allows you to assign custoemrs with tickets
        if ticket.seat = seats then
            { ticket with customer = customers}
        else 
            ticket
    tickets <- List.map assignCustomer tickets

//print menu function
let printMenu () =
    while true do
        printfn "1. Display all tickets"
        printfn "2. Book Seats with customer name and seat number"
        printfn "3. Exit"
        printfn "Enter your choice: "
        let input = System.Console.ReadLine() 
        match input with // matches desired input and matches number with input value
        | "1" -> DisplayTicket ()
        | "2" -> printfn "Please enter customer name"
                 let customers = System.Console.ReadLine()
                 printfn "Please seat number "
                 let seats = int (System.Console.ReadLine())
                 OrderSeat (customers, seats)
        | "3" -> exit 0 
        | _ -> printfn "Incorrect input Please try again"

printMenu ()

