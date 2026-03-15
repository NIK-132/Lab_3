// Задание 2. Вариант 7.
// Найти самую короткую строку в последовательности строк.

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

/// Создаёт последовательность строк заданной длины
let readStrings count =
    seq {
        for i in 1 .. count do
            printf "Введите строку %d: " i
            yield Console.ReadLine()
    }

[<EntryPoint>]
let main _ =
    let count = readInt "Введите количество строк: "
    let strings = readStrings count

    // Находим самую короткую строку с помощью Seq.fold, используя Option
    let shortestOption =
        strings
        |> Seq.fold (fun acc s ->
            match acc with
            | None -> Some s                     // первая строка
            | Some prev ->
                if String.length s < String.length prev then Some s else Some prev
        ) None

    // Извлекаем значение (последовательность не пуста, так как count > 0)
    let shortest = shortestOption.Value

    printfn "\nСамая короткая строка: \"%s\"" shortest
    printfn "Её длина: %d" (String.length shortest)

    0