open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData() = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec accCond  (f : int -> int -> int) p acc list = 
    match list with
    | [] -> acc
    | h::t ->
                let newAcc = f acc h
                if p h then accCond  f p newAcc t // если предикат возвращает true, тогда передадим обновленный акамулятор
                else accCond f p acc t

let listMin list = 
    match list with 
    |[] -> 0
    | h::t -> accCond  (fun x y -> if x < y then x else y) (fun x -> true) h list

let max2 x y = if x > y then x else y

let listMax list = 
    match list with 
    |[] -> 0
    | h::t -> accCond  max2 (fun x -> true) h list

// 1.5 
//глобальный минимум - меньше всех элементов в массиве
let CheckGlobalMin list (ind:int) = 
    let min = listMin list
    let rec CheckGlobalMin1 list num curnum = 
        match list with 
            | [] -> false
            | h :: t -> 
                        if num = curnum then ( h = min)
                        else CheckGlobalMin1 t num (curnum + 1)
                        
    CheckGlobalMin1 list ind 1

//1.15
//локальный минимум - меньше левого и правого соседа если они есть
let CheckNextLess list el =
    match list with
     | [] -> true //получается следующего (правого) элемента нет 
     | h :: t ->
                 if el < h then true
                 else false

let CheckLocalMin list (ind:int) = 
    let rec CheckLocalMin1 list num curnum prev = 
        match list with 
            | [] -> false
            | h :: t -> 
                        if num = curnum then (if h < prev then (CheckNextLess t h) else false )
                        else CheckLocalMin1 t num (curnum + 1) h        
    CheckLocalMin1 list ind 1 9999

//1.25
let rec GetABSpisok2 list (b:int) curnum =
    match list with 
            | [] -> []
            | h :: t -> 
                         if curnum = b then h :: []
                         else 
                            let Tail =  (GetABSpisok2 t  b (curnum+1))
                            h :: Tail
                            
let rec GetABSpisok1 list (a:int) (b:int) curnum = 
    match list with 
            | [] -> []
            | h :: t -> 
                        if curnum = a then (GetABSpisok2 list b curnum)
                        else GetABSpisok1 t a b (curnum + 1)


let FindMaxInInterval list (a:int) (b:int) = 
    let newList = GetABSpisok1 list a b 1
    listMax newList

//1.35
let ClosestNum list (num: float) =
    let rec ClosestNum1 list num f (acc:float)  =
        match list with 
            |[] -> acc
            |h::t ->
                    let newAcc = f num h acc
                    ClosestNum1 t num f newAcc

    ClosestNum1 list num (fun x y z-> (if abs (x-y) < abs (x-z) then y else z)) 99999

//1.45
let SumNumsInInterval list (a:int) (b:int) = 
    let rec SumNumInInterval1 list a b acc = 
        match list with 
            | [] -> acc
            | h::t -> 
                        let newAcc = acc + h
                        if (h <= b && h >= a) then  SumNumInInterval1 t a b newAcc
                        else SumNumInInterval1 t a b acc
    SumNumInInterval1 list a b 0

//1.55
let rec frequency list elem count =
        match list with
        |[] -> count
        | h::t -> 
                        let count1 = count + 1
                        if h = elem then frequency t elem count1 
                        else frequency t elem count

let rec freqPairs acc list =
    match list with
    | [] -> acc  //возвращаем список пар, (x, y) где x - элемент списка, y - то сколько раз x встретился в списке
    | h::t ->
        if List.exists (fun (x, _) -> x = h) acc then
            freqPairs acc t//Если элемент уже учтён, пропускаем
        else
            freqPairs ((h, frequency list h 0)::acc) t  //Добавляем новую пару

let rec sortPairsByFreq pairs =  //список пар, snd h дает нам второй элемент в паре h, то есть частоту
    match pairs with
    | [] -> []
    | [x] -> [x]
    | h::t ->  //h - опорный элемент
        let (less, greater) = List.partition (fun (_, x) -> x <= snd h) t // (fun (_, x) -> x <= snd h) - предикат, less - элементы, для которых predicate вернул true
        (sortPairsByFreq greater) @ [h] @ (sortPairsByFreq less) // рекурсивно сортируем по убыванию, потом соединяем

let rec resList pairs =
    match pairs with
    | [] -> []
    | (elem, cnt)::t -> 
        let rec repeat elem n acc = //acc это список из el повторенного cnt раз
            if n <= 0 then acc else repeat elem (n-1) (elem::acc)
        (repeat elem cnt []) @ resList t 

let sortByFrequency (list:int list) =  // Основная функция
    list |> freqPairs [] |> sortPairsByFreq |> resList


//10
let rec readListStr n = 
    if n=0 then []
    else
    let Head = System.Console.ReadLine()
    let Tail = readListStr (n-1)
    Head::Tail
let readDataStr() = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readListStr n

let sortedByLength strings: string list = 
    List.sortBy (fun s -> s.Length) strings 
   

//17


//18
let cifrsToNumber (arr: int[]) =
    arr |> Array.fold (fun acc cifr -> acc * 10 + cifr) 0 //преобразуем массив цифр в число

let inputArray() = 
    let inp = Console.ReadLine() //получили строку
    inp.Split([|' '|]) |> Array.map int |> Array.filter (fun x -> (x >= 0 && x <= 9)) 

//19
//списки нельзя менять после создания, массиы - мутабельны (изменяемы)
let MixString (str: string) =
    let r = Random() // экземпляр генератора случайных чисел
    str.ToCharArray()
    |> Array.toList 
    |> List.sortBy (fun _ -> r.Next()) // анонимная функция принимает элемент списка но игнорирует его _ и возвращает число из рандома
    |> List.toArray // из списка в массив
    |> String 


//20
let mediana (s: string) =
    let str = s.ToCharArray() |> Array.sort
    let l= str.Length
    if l % 2 = 1 then float str.[l / 2]
    else (float str.[l / 2 - 1] + float str.[l / 2]) / 2.0 // для четной длины среднее арифметической значений по середине

// Основная функция сортировки
let sortByMediana (strings: string list) =
    let rec sortByMediana1 list res = //list список пар (строка, ее медиана)
        match list with
        | [] -> res 
        | _ ->
            let medians = list |> List.map (fun s -> (s, mediana s))
            let maxMediana = medians |> List.maxBy snd
            let newList = list |> List.filter (fun y -> y <> (fst maxMediana))
            sortByMediana1 newList ((fst maxMediana) :: res)
    sortByMediana1 strings []

[<EntryPoint>]
let main argv = 
    //let l = readData()
    //1.5
    //Console.WriteLine($"Глобальный минимум {CheckGlobalMin l 4}")

    //1.15
    //Console.WriteLine($"Локальный минимум {CheckLocalMin l 4}")

    //1.25
    //Console.WriteLine($"Максимальный элемент в интервале 3 6 это {FindMaxInInterval l 3 6}")

    //1.35
    //let l_v = [3.23; 45.1; 76.7; 8.12; 123.123; 48.1008; 48.9; 17.6]
    //Console.WriteLine($"Ближайшее к числу 48,6 в массиве = {ClosestNum l_v 48.6}")

    //1.45
    //Console.WriteLine($"Сумма элементов которые попадают в интервал 4 10 равна {SumNumsInInterval  l 4 10}")

    //1.55
    //let m = [5;6;2;2;3;3;3;5;5;5] 
    //printfn "%A" (sortByFrequency m)

    //10
    //let strings = readDataStr()
    //printfn "%A" (sortedByLength strings)

    //18
    //let arr1 = inputArray()
    //let arr2 = inputArray()
    //Console.WriteLine($"Разность arr1 - arr2 = {(cifrsToNumber arr1) - (cifrsToNumber arr2)}")

    //19
    //let str = Console.ReadLine()
    //Console.WriteLine($"Перемешенная строка {MixString str}")

    //20
    let list_str = ["max"; "recursion"; "film"; "standart"; "pianino"; "voice"; "snowman"]
    printfn "%A"  (sortByMediana list_str)
    0
