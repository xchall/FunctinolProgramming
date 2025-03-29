open System

//реккурсия вверх
let rec sum_cifr x = 
    if x / 10 = 0 then x%10 //дно реккурсии
    else (x % 10) + sum_cifr (x / 10)  

let main () = 
    Console.Write("Введите число для подсчета суммы цифр: ")
    let num = Console.ReadLine() |> int
    Console.WriteLine($"Сумма цифр (найдено при помощи реккурсии вверх) {sum_cifr num}")
main () 