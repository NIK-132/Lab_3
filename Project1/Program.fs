// Задание 1. Вариант 7.
// На основе последовательности строк получить новую последовательность,
// где к каждой строке в конце дописан заданный символ.

open System

/// Ввод целого положительного числа с повторением при ошибке
let rec readInt prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | true, value when value > 0 -> value
    | _ ->
        printfn "Ошибка: введите положительное целое число."
        readInt prompt

/// Ввод одного символа с проверкой
let rec readChar prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    if String.length input = 1 then input.[0]
    else
        printfn "Ошибка: требуется ровно один символ."
        readChar prompt

/// Создаёт последовательность строк заданной длины
let readStrings count =
    seq {
        for i in 1 .. count do
            printf "Введите строку %d: " i
            yield Console.ReadLine()
    }

/// Добавляет символ в конец каждой строки последовательности
let appendCharToAll ch strings =
    strings |> Seq.map (fun s -> s + string ch)

[<EntryPoint>]
let main args =
    let count = readInt "Введите количество строк: "
    let symbol = readChar "Введите символ для добавления: "
    let sequence = readStrings count
    let result = appendCharToAll symbol sequence

    printfn "Результат: %A" (result |> Seq.toList)
    0