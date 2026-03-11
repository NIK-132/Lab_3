// Задание 2. Вариант 7.
// Найти самую короткую строку в последовательности строк.

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

    // Поиск самой короткой строки с помощью Seq.fold
    // Начальное значение – первая строка
    let shortest =
        strings
        |> Seq.fold (fun acc s ->
            if String.length s < String.length acc then s else acc
        ) (Seq.head strings)

    printfn "\nИсходный список: %A" (strings |> List.ofSeq)
    printfn "Самая короткая строка: \"%s\"" shortest
    printfn "Её длина: %d" (String.length shortest)

    0