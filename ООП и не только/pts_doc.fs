open System
open System.Text.RegularExpressions

type CarCategory = A | B | C | D | E

let tryFromString (str: string) =
    match str.Trim().ToUpper() with
    | "A" -> Some A
    | "B" -> Some B //использую опциональный тип
    | "C" -> Some C
    | "D" -> Some D
    | "E" -> Some E
    | _ -> None

type CarPassport(VIN: string, BrandModel: string, carType: string, Category: string, ManufactureYear: int, Color: string) =
    do 
        if not (CarPassport.ValidateVin VIN) then 
             invalidArg (nameof(VIN)) "Неверный формат VIN (должен быть 17 символов: буквы и цифры)"
        if not (CarPassport.ValidateBrandModel BrandModel) then 
            invalidArg (nameof(BrandModel)) "Неверный формат марки/модели"
        if not (CarPassport.ValidateCarType carType) then 
            invalidArg (nameof(carType)) "Неверный тип транспортного средства"
        if ((tryFromString Category) = None) then
                invalidArg (nameof(Category)) $"Недопустимая категория: {Category}"
        if not (CarPassport.ValidateYear ManufactureYear) then 
            invalidArg (nameof(ManufactureYear)) $"Неверный год производства (должен быть между 1900 и {DateTime.Now.Year + 1})"
        if not (CarPassport.ValidateColor Color) then 
            invalidArg (nameof(Color)) "Неверный формат цвета"

    //далее конструктор котырый выполниться после всех успешных валидаций
    member this.VIN = VIN
    member this.BrandModel = BrandModel
    member this.carType = carType
    member this.Category = Category
    member this.ManufactureYear = ManufactureYear
    member this.Color = Color

    static member ValidateVin(vin: string) =
        Regex.IsMatch(vin, "^[A-HJ-NPR-Z0-9]{17}$")
    
    static member ValidateBrandModel(brandModel: string) =
        Regex.IsMatch(brandModel, "^[A-Za-zА-Яа-я0-9\\s-]{1,100}$")
    
    static member ValidateCarType(carType: string) =
        Regex.IsMatch(carType, "^[A-Za-zА-Яа-я\\s-]{5,100}$")
    
    static member ValidateYear(year: int) =
        year >= 1900 && year <= DateTime.Now.Year
    
    static member ValidateColor(color: string) =
        Regex.IsMatch(color, "^[A-Za-zА-Яа-я\\s-]{3,20}$")

    member this.Print() =
        Console.WriteLine("Паспорт транспортного средства")
        Console.WriteLine( "-----------------------------------")
        Console.WriteLine($"VIN: {this.VIN}")
        Console.WriteLine($"Марка и модель: {this.BrandModel}")
        Console.WriteLine($"Тип ТС: {this.carType}")
        Console.WriteLine($"Категория: {this.Category}")
        Console.WriteLine($"Год изготовления: {this.ManufactureYear}")
        Console.WriteLine($"Цвет: {this.Color}")
        Console.WriteLine("------------------------------------")
    
    //Сравнение по VIN номеру
    interface IComparable with
        member this.CompareTo(other) =
            match other with
            | :? CarPassport as otherPassport ->  // :? проверка типа
                String.Compare(this.VIN, otherPassport.VIN, StringComparison.Ordinal) //StringComparison.Ordinal — сравнение по байтам, регистрозависимое
            | _ -> -1

//Тесты
try
        let pts1 = CarPassport(
            "XTA21099734678901",
            "LADA Vesta",
            "Легковой автомобиль",
            "B",
            2022,
            "Серый"
        )
        
        let pts2 = CarPassport(
            //"Z94CB41AAGR323020",
            "XTA21099734678901",
            "Hyundai Solaris",
            "Легковой автомобиль",
            "B",
            2021,
            "Белый"
        )

        let pts3 = CarPassport(
            "XTA12345678901234",
            "КамАЗ 65201",
            "Грузовик",
            "C",
            2009,
            "Серый"
        )

        let pts4 = CarPassport(
            "HD123456789012345",
            "Harley-Davidson Sportster",
            "Мотоцикл",
            "A",
            2014,
            "Зеленый"
        )

        pts1.Print()
        pts2.Print()
        pts3.Print()
        pts4.Print()
        Console.WriteLine("\nСравнение документов")
        Console.WriteLine($"Сравнение PTS1 и PTS2: {compare pts1 pts2}") //Функция compare автоматически вызывает CompareTo, если тип реализует IComparable
        
        Console.WriteLine("\nВалидация полей")
        try
            let invalidPts = CarPassport(
                "12322",//Неверный 
                "LADA",
                "Легковой",
                "B",
                1800,//Неверный 
                "Красный"
            )
            invalidPts.Print()
        with ex -> 
            Console.WriteLine($"Ошибка валидации: {ex.Message}")
    with ex ->
        Console.WriteLine($"Ошибка: {ex.Message}")
