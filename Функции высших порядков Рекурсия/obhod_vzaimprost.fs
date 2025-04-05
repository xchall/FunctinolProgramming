open System

let vzaimnoProst (num1:int) (num2:int) = 
    let rec loop x =
        match x with
        | 1 -> true
        | _ -> (if num1 % x = 0 then (if num2 % x = 0 then false else loop (x-1)) else loop (x-1))
    loop num1 

let obhod num (f: int -> int -> int) init = 
    let rec loop x acc = 
        match x with 
        | _ when num = x -> acc
        | _ -> (if (vzaimnoProst x num) = true then ((f x acc) |> loop (x+1))  else (loop (x+1) acc))
    loop 1 init
let euler num = 
    obhod num (fun x y -> y + 1) 0
let main () = 
    let ans1 = obhod 8 (fun x y -> x + y) 0
    Console.WriteLine($"{ans1}") 
    let ans2 = obhod 17 (fun x y -> x + y) 0
    Console.WriteLine($"{ans2}") 
    let ans3 = euler 27
    Console.WriteLine($"Количество взаимнпростых с 27 равно {ans3}") 
main()