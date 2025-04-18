open System
// Агент для печати сообщений
let printerAgent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop() = async {
        let! msg = inbox.Receive()//чтение сообщения, let! освобождает поток во время ожидания
        printfn  msg
        return! messageLoop()
    }
    messageLoop()
)

let rnd = Random()
// Синхронная отправка сообщений
let sendMessagesSync () =
    for i in 1..20 do
        let points = rnd.Next(0, 101)
        printerAgent.Post( $"Сообщение {i}: Вы набрали {points} баллов")

sendMessagesSync()
Async.Sleep(1000) |> Async.RunSynchronously  //даём время агенту обработать сообщения

