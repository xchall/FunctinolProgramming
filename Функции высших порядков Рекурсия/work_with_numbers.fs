open System

//реккурсия вверх
let rec sum_cifr x = 
    if x / 10 = 0 then x%10 //дно реккурсии
    else (x % 10) + sum_cifr (x / 10)  

//хвостовая реккурсия 
let sum_cifr_hvost x =
    let rec loop num acc = 
        if num / 10 = 0 then acc + (num%10) 
        else loop (num / 10) (acc + (num % 10)) 
    loop x 0

let main () = 
    Console.Write("Введите число для подсчета суммы цифр: ")
    let num = Console.ReadLine() |> int
    Console.WriteLine($"Сумма цифр (найдено при помощи реккурсии вверх) {sum_cifr num}")
    Console.WriteLine($"Сумма цифр (найдено при помощи хвостовой реккурсии) {sum_cifr_hvost num}")
main () 