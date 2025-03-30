open System
//вариант 5 для задания 16
//1
let amountDeviders num =
    let rec loop n (f: int-> int-> bool) acc (p:int->bool) = 
        match n with
        | 0 -> acc
        | _ -> 
            let newAcc = if f num n then (if p n then (acc+1) else acc) else acc
            loop (n-1) f newAcc p
    loop num (fun x y -> if x % y =0 then true else false) 0 (fun x -> if x % 3 =0 then false else true)

//2 
let minNechCifr num  = 
    let rec loop n (f: int-> int-> int) acc (p:int->bool) = 
        match n with
        | 0 -> acc
        | _ -> 
            let nAcc = (if p (n%10) then (f acc (n%10)) else acc)
            loop (n/10) f nAcc p
    loop num (fun x y -> (if x < y then x else y)) 10 (fun x -> if x%2<>0 then true else false)

//3
let sum_cifr_hvost x =
    let rec loop num acc = 
        if num / 10 = 0 then acc + (num%10) 
        else loop (num / 10) (acc + (num % 10)) 
    loop x 0

let mult_cifr_hvost x =
    let rec loop num acc = 
        if num / 10 = 0 then acc * (num%10) 
        else loop (num / 10) (acc * (num % 10)) 
    loop x 1

let vzaimnoProst (num1:int) (num2:int) = 
    let rec loop x =
        match x with
        | 1 -> true
        | _ -> (if num1 % x = 0 then (if num2 % x = 0 then false else loop (x-1)) else loop (x-1))
    loop num1 

let sumDeviders num =
    let sumCifr = (sum_cifr_hvost num)
    let multCifr = (mult_cifr_hvost num)
    let rec loop x acc (f:int->int->bool)=
        match x with
        | 0 -> acc
        | _ -> 
            let newAcc = if num % x= 0 then (if (f x sumCifr) then (if (f x multCifr) then acc else (acc+x)) else acc) else acc  
            loop (x-1) newAcc f
    loop num 0 vzaimnoProst

let main () = 
    let ans1 = amountDeviders 15
    Console.WriteLine($"Количество делителей числа, не делящихся на 3 = {ans1}")
    let ans2 = minNechCifr 667372
    Console.WriteLine($"Минимальная нечетная цифра (если ответ = 10, то нечетных цифр нет) = {ans2}")
    let ans3 = sumDeviders 76
    Console.WriteLine($"Cумма всех делителей числа, взаимно простых с суммой \nцифр числа и не взаимно простых с произведением цифр числа = {ans3}")
main()
