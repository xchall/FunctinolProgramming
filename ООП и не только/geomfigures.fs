open System

//lab 4
[<AbstractClass>]
type GeomFig() =
    abstract FindS: unit -> float //вирутальный метод для вычисления площади (не принимает параметров, возвращает float)
    //можно без реализации по умолчанию default, если она не требуется

type IPrint = interface //можно без interface и end
    abstract member Print: unit -> unit
    end

type Rectangle(ap:float, bp:float)=
    inherit GeomFig()

    //локальные переменные
    let mutable a = ap//не член класса
    let mutable b = bp

    //публичное свойство property
    member this.ReadWriteA
        with get() = a
        and set(value) = a <- value

    member this.ReadWriteB
        with get() = b
        and set(value) = b <- value

    override this.FindS() = 
        a * b

    override this.ToString() = 
        $"Прямоугольник с шириной {a} и высота {b} и площадью {this.FindS()}"
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())


type Square(ap:float)=
    inherit Rectangle(ap, ap)

    override this.ToString() = 
        $"Квадрат со стороной {this.ReadWriteA} и площадью {this.FindS()}"

    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())


type Circle(radiusp:float)=
    inherit GeomFig()
    let mutable radius = radiusp

    member this.ReadWriteRadius
        with get() = radius
        and set(value) = radius <- value

    override this.FindS() = 
        Math.PI * radius * radius

    override this.ToString() = 
        $"Круг с радиусом {this.ReadWriteRadius} и площадью {this.FindS()}"

    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())

// || - банановые клипсы
// discriminatedunion
type Figure =
    | Rect of width : float * height : float
    | Squ of side : float
    | Circ of radius : float

let findS (figure : Figure) = 
   match figure with
   | Rect (a, b) -> a*b
   | Squ a -> a * a
   | Circ r -> Math.PI * r * r
     

[<EntryPoint>]
let main argv =
    //4.1
    let s1 = Square(4)
    let ss1 = s1 :> IPrint //явное приведение к интрефейсу
    ss1.Print()
    let c1 = Circle(3.5)
    c1.ReadWriteRadius <- 6
    let cc1 = c1 :> IPrint 
    cc1.Print()
    let r1 = Rectangle(2, 15.89)
    let rr1 = r1 :> IPrint 
    rr1.Print()
    Console.WriteLine(r1.ReadWriteB)
    r1.ReadWriteB <- 3
    let rr2 = r1 :> IPrint 
    rr2.Print()

    //4.2
    let rect = Rect(5, 4)
    let sq = Squ 5.6
    let circle = Circ 3.2
    Console.WriteLine($"Площадь прямоугольника {findS rect}")
    Console.WriteLine($"Площадь квадрата {findS sq}")
    Console.WriteLine($"Площадь круга {findS circle}")
    0 

