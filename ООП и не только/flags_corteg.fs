open System
open System.Windows.Forms
open System.Drawing

let mainForm = new Form(Text = "Флажки с кортежами", Width = 300, Height = 200)

let checkBox1 = new CheckBox(Text = "1ый флажок", Location = Point(20, 20), Width = 150)
let checkBox2 = new CheckBox(Text = "2ой флажок", Location = Point(20, 50), Width = 150)
let button = new Button(Text = "Проверить", Location = Point(20, 80), Width = 150)

let getMessage (state1, state2) =
    match state1, state2 with
    | true, false -> "Установлен первый флажок"
    | false, true -> "Установлен второй флажок"
    | true, true -> "Установлены оба флажка"
    | _ -> "Ни один флажок не установлен"

button.Click.Add(fun _ ->
    let states = (checkBox1.Checked, checkBox2.Checked) //Создаем кортеж состояний
    let message = getMessage states
    MessageBox.Show(message) |> ignore//так как MessageBox.Show возвращает какая кнопка была нажата 
)

mainForm.Controls.Add(checkBox1)
mainForm.Controls.Add(checkBox2)
mainForm.Controls.Add(button)

Application.Run(mainForm)