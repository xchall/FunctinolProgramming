open System

let answ_to_user (x: string) =
    match x with 
        | "F#" -> "А ты подлиза"
        | "Prolog" -> "А ты подлиза"
        | "Ruby" -> "Хорош"
        | _ -> "Сойдет"

let main () = 
     Console.WriteLine("Какой твой любимый язык программирования?")
     let lang = Console.ReadLine()
     Console.WriteLine($"{answ_to_user(lang)}")
main()