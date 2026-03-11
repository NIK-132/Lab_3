// Задание 3. Вариант 7.
// Вывести последний по алфавиту файл в указанном каталоге.

open System
open System.IO

/// Ввод строки с клавиатуры
let readString prompt =
    printf "%s" prompt
    Console.ReadLine()

[<EntryPoint>]
let main args =

    let path = readString "Введите путь к каталогу: "

    // Проверяем, существует ли каталог
    if Directory.Exists path then
        // Получаем последовательность имен файлов (только имена, без пути)
        let files = Directory.EnumerateFiles path |> Seq.map Path.GetFileName

        // Проверяем, есть ли файлы
        if Seq.isEmpty files then
            printfn "В каталоге нет файлов."
        else
            // Берём первый файл как начальное значение
            let first = files |> Seq.head

            // Проходим по остальным файлам и сравниваем
            let lastFile =
                files
                |> Seq.fold (fun acc current ->
                    // Сравниваем строки в порядке алфавита
                    if String.Compare(current, acc, StringComparison.Ordinal) > 0 then
                        current
                    else
                        acc
                ) first

            printfn "Последний по алфавиту файл: %s" lastFile
    else
        printfn "Указанный каталог не существует."

    0