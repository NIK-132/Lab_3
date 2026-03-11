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
    | true, _ ->
        printfn "Ошибка: число должно быть положительным. Повторите ввод."
        readInt prompt
    | false, _ ->
        printfn "Ошибка: введите целое число. Повторите ввод."
        readInt prompt

/// Ввод строки
let readString prompt =
    printf "%s" prompt
    Console.ReadLine()

/// Ввод одного символа с проверкой
let rec readChar prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    if String.length input = 1 then
        input.[0]
    else
        printfn "Ошибка: требуется ровно один символ. Повторите ввод."
        readChar prompt

/// Создаёт последовательность строк заданной длины
let readStringsSeq count =
    seq {
        for i in 1 .. count do
            let s = readString (sprintf "Введите строку %d: " i)
            yield s
    }

[<EntryPoint>]
let main args =
    
    let n = readInt "Введите количество строк: "

    // Получаем последовательность строк и кэшируем её,
    // чтобы можно было использовать несколько раз без повторного ввода
    let strings = readStringsSeq n |> Seq.cache

    let ch = readChar "Введите символ для добавления: "

    let result = strings |> Seq.map (fun s -> s + string ch)

    printfn "\nИсходный список: %A" (strings |> List.ofSeq)
    printfn "Результирующий список: %A" (result |> List.ofSeq)

    0