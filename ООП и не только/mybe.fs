open System

type Maybe<'a> =
    | Just of 'a
    | Nothing 

let fmap f (x_in_context: Maybe<'a>) =
    match x_in_context with
    | Just a -> Just (f a)
    | Nothing -> Nothing
//
let apply f_in_context (x_in_context: Maybe<'a>) = 
    match f_in_context, x_in_context with
    | Just f, Just x -> Just(f x)
    | _ -> Nothing

let apply2 (x_in_context: Maybe<'a>) f_in_context = 
    match f_in_context, x_in_context with
    | Just f, Just x -> Just(f x)
    | _ -> Nothing

let lift x = //Функция return(lift) поднимает значение в контекст.
     Just x
//
let bind (f: 'a -> Maybe<'b>) (x_in_context: Maybe<'a>) = // аргумент функции 'a не поднятый, а вот к чему применяем поднято значение у монады
    match x_in_context with
    | Just x -> f x //возвращается поднятое, согласно f
    | Nothing -> Nothing


//проверка законов для функтора
let id x = x
let value = Just 5
let ans = fmap id value//1. Закон сохранения идентичности 
Console.WriteLine(ans)

let f x = x + 3.0
let g x = x * 0.5

let y = Just 15.0
let ans1_1 = fmap f y 
let ans1_2 = fmap g ans1_1  
let ans2 = fmap (f >> g) y
Console.WriteLine((ans1_2, ans2))//2. Закон композиции

//проверка законов для апликативного функтора
let k1 = id 5
let k2 = apply (Just id) value
Console.WriteLine((k1, k2))//1.
//y = f(x)
let kk1 = apply (Just f) (Just 10)
let res = f 10
let kk2 = lift(res)
Console.WriteLine((kk1, kk2))//2.

let kkk1 = apply (Just f) (Just 14.0)
let kkk2 = apply2 (Just 14.0) (Just f)
Console.WriteLine((kkk1, kkk2))//3.
//продемонстрировать правило 4 невозможно (Композиция функций apply ассоциативна.)


//проверка законов для монады

let ff x = Just (x * 3.0)  //значение поднято, аргумент не поднят
let x = 17.7
Console.WriteLine((( bind ff (lift x) ), ff x )) 

let p = lift 1
let lift_lifted = bind lift p
let iddd= id (lift 1)
Console.WriteLine((lift_lifted, iddd))//1. lift_lifted эквивалентен id

//2. закон не получится сделать, не можем передать в bind только функцию

let fff x = Just (x + 3.0)
let ggg x = Just (x * 4.0)
let m = Just 3.0
//let groupFromTheLeft = (a >>= f) >>= g
//let groupFromTheRight = a >>= (fun x -> f x >>= g)
//ниже тоже самое но в bind по другому аргуменнты передаются, не как в >>=
//Console.WriteLine((( bind ggg (bind fff m)) = () )) //неполучится проверить ассоциативность 3 закон
//3. В неподнятом состоянии композиция функций ассоциативна: