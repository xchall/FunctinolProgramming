open System

let answ_to_user (x: string) =
    match x with 
        | "F#" -> "А ты подлиза"
        | "Prolog" -> "А ты подлиза"
        | "Ruby" -> "Хорош"
        | _ -> "Сойдет"
let output_ans (f: string -> string) x =
    Console.WriteLine($"{f x}")
let main () = 
     Console.WriteLine("Какой твой любимый язык программирования?") 
     //при помощи суперпозиции
     (Console.ReadLine >> answ_to_user >> Console.WriteLine) ()
     //при помощи каррирования
     let get_ans = output_ans answ_to_user
     let x = Console.ReadLine() |> string
     get_ans x

main()