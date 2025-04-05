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

let rec amount_deviders (x:int) (del:int) =
    match del with
    | 0 -> 0
    | _ when ((x % del) = 0) -> (1 + (amount_deviders x (del-1)))
    | _ -> amount_deviders x (del-1)

let amount (x:int) = 
    amount_deviders x x

let amount_deviders_hvost (x:int) =
    let rec loop num del acc = 
         match del with
        | 0 -> 0
        | _ when ((num % del) = 0) -> (loop num (del-1) acc+1)
        | _ -> loop num (del-1) acc
    loop x x 0


let dificult_func (flag: bool) = 
    match flag with
    | true -> sum_cifr_hvost 
    | false -> amount_deviders_hvost

//7,8
let rec cifirFold (num:int) (f:int->int->int) (acc:int) =
    match num with
    | 0 -> acc
    | _ -> 
        let numAcc = f acc (num % 10)
        cifirFold (num/10) f numAcc 
//9-10
let rec cifirFoldSecond (num:int) (f:int->int->int) (acc:int) (p:int->bool) =
    match num with
    | 0 -> acc
    | _ -> 
        let numAcc = (if p (num%10) then (f acc (num%10)) else acc)
        cifirFoldSecond (num/10) f acc p
    
let main () = 
    //Console.Write("Введите число для подсчета суммы цифр: ")
    //let num = Console.ReadLine() |> int
    //Console.WriteLine($"Количсетво делителей числа (реккурсия вверх) {amount num }")
    //Console.WriteLine($"Количсетво делителей числа (хвостовая реккурсия) {amount_deviders_hvost num }")
    //let func = dificult_func false
    //Console.WriteLine($" {func num}")
    //Console.WriteLine($"Сумма цифр (найдено при помощи реккурсии вверх) {sum_cifr num}")
   // Console.WriteLine($"Сумма цифр (найдено при помощи хвостовой реккурсии) {sum_cifr_hvost num}")
    Console.WriteLine($"Сумма цифр {cifirFold 781 (fun x y -> (x+y)) 0}")
    Console.WriteLine($"Произведение цифр {cifirFold 781 (fun x y -> x*y) 1}")
    Console.WriteLine($"Минимум {cifirFold 781 (fun x y -> if x < y then x else y) 10}")
    Console.WriteLine($"Максимум {cifirFold 781 (fun x y -> if x > y then x else y) 0}")
main () 