open System
open System.Windows.Forms
open System.Drawing

// Создаем главную форму
let mainForm = new Form(Text = "Определение времени года", Width = 300, Height = 200)

// Создаем выпадающий список с месяцами
let monthComboBox = new ComboBox(
    Location = Point(50, 30),
    Width = 200,
    DropDownStyle = ComboBoxStyle.DropDownList
)

["Январь"; "Февраль"; "Март"; "Апрель"; "Май"; "Июнь";
 "Июль"; "Август"; "Сентябрь"; "Октябрь"; "Ноябрь"; "Декабрь"]
|> List.iter (monthComboBox.Items.Add >> ignore)

let determineButton = new Button(
    Text = "Определить время года",
    Location = Point(50, 70),
    Width = 200
)

let resultLabel = new Label(
    Location = Point(80,110),
    Width = 200,
    TextAlign = ContentAlignment.MiddleCenter
)

let getSeason month =
    match month with
    | "Декабрь" | "Январь" | "Февраль" -> "Зима"
    | "Март" | "Апрель" | "Май" -> "Весна"
    | "Июнь" | "Июль" | "Август" -> "Лето"
    | "Сентябрь" | "Октябрь" | "Ноябрь" -> "Осень"
    | _ -> "Неизвестный месяц"

//обработчик нажатия на кнопку
determineButton.Click.Add(fun _ ->
    if monthComboBox.SelectedIndex >= 0 then //-1 если ничего не выбрано
        let month = monthComboBox.SelectedItem.ToString()
        let season = getSeason month
        resultLabel.Text <- season
    else
        resultLabel.Text <- "Выберите месяц из списка"
)


mainForm.Controls.Add(monthComboBox)
mainForm.Controls.Add(determineButton)
mainForm.Controls.Add(resultLabel)

Application.Run(mainForm)