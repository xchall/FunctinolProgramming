open System

//рекурсия вниз
let AryfmProgrOf3 (cur_num:int) (step:int) = 
    let rec progression acc num st = // acc список из трех чисел прогрессии получим (список как раз будем получать в порядке, например [3,2,1], что удобно для этой задачи)
        match List.length acc with 
        | 3 -> 
            acc
        | _ ->
            let newAcc = num :: acc
            let nextNum = num + st
            progression newAcc nextNum st

    progression [] cur_num step

let countXYZ (list:int List) = 
    let squares = List.map (fun x-> x*x) list
    match squares with
    | head :: tail -> head - (List.reduce (fun acc x -> acc + x) tail) 

//реккурсия вниз
let updateByIndex (index:int) (list:int List) = 
    let rec loop curPos spis resList=
        match spis with
        |[]-> List.rev resList
        |head::tail -> 
                    if curPos = index then
                        let newHead = head + 1
                        (List.rev (newHead :: resList)) @ tail // дно рекурсии, обязаны дойти до index
                    else 
                        let newCurPos = curPos + 1
                        let newResList = head :: resList
                        loop newCurPos tail newResList
                        
    loop 1 list [] //важно! индексация 


let FindAnsSameDifferences current_limit =
//n = u* v
    let rec loop u v acc =
        let p = 3*v - u
        match p, v, u with 
        |_,_,_ when (p > 0 && p % 4 = 0) && (u*v <= current_limit) -> 
                                let newAcc = updateByIndex (u * v) acc
                                loop u (v + 1) newAcc
        |_,_,_ when (u*v <= current_limit) -> 
                                loop u (v + 1) acc
        |_,_,_ when (u < current_limit) -> 
                                loop (u + 1) 1 acc
        |_,_,_  -> acc //дно

    let zeros = List.init (current_limit+1) (fun _ -> 0)
    loop 1 1 zeros

let FindAnsSameDifferences2 current_limit =
    let acc = Array.zeroCreate (current_limit + 1) //массив вместо списка
    
    let rec loop u v =
        let p = 3*v - u
        match p, v, u with 
        |_,_,_ when (p > 0 && p % 4 = 0) && (u*v <= current_limit) -> 
                                let n = u * v
                                acc.[n] <- acc.[n] + 1
                                loop u (v + 1) 
        |_,_,_ when (u*v <= current_limit) -> 
                                loop u (v + 1) 
        |_,_,_ when (u < current_limit) -> 
                                loop (u + 1) 1
        |_,_,_  -> acc //дно
     
    loop 1 1

[<EntryPoint>]
let main argv =
    let answer1 = 
            FindAnsSameDifferences 20000 
            |> List.filter (fun x -> x = 10) 
            |> List.length
    Console.WriteLine($"{answer1}")
    let answer2 = 
        FindAnsSameDifferences2 20000
        |> Array.filter (fun x -> x = 10) 
        |> Array.length
    Console.WriteLine($"{answer2}")

    0
