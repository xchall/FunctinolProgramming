open System

let circleS r = Math.PI * r * r
let cylinderV h S = S * h

let main () = 
    Console.Write("Введите радиус круга: ")
    let r = Console.ReadLine() |> double
    Console.Write("Введите высоту цилиндра: ")
    let h = Console.ReadLine() |> double
    let S = circleS r
    Console.WriteLine($"Площадь круга = {S}")
    let findV = circleS >> cylinderV 
    Console.WriteLine($"Объем цилиндра = {(findV r h)}")

main () //запускаем прогу