document.getElementById('fileInput').addEventListener('change', handleFile);

function saveToFile() {
    const result = document.getElementById('resultText').value;

    if (!result.trim()) {
        alert('Поле результата пустое, нечего сохранять!');
        return;
    }

    // Создаем Blob из результата
    const blob = new Blob([result], { type: 'text/plain' });

    // Создаем ссылку для скачивания
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'result.txt'; // Имя сохраняемого файла

    // Симулируем клик для открытия диалогового окна
    link.click();

    // Очищаем созданный объект
    URL.revokeObjectURL(link.href);
}
// utils
function Reset(onlyResult) {
    const resultText = document.getElementById('resultText');
    if (resultText !== null) {
        resultText.value = '';
    }
    if (onlyResult) return;
    const inputKey1 = document.getElementById('input-key1');
    if (inputKey1 !== null) {
        inputKey1.value = '';
    }
    const inputKey2 = document.getElementById('input-key2');
    if (inputKey2 !== null) {
        inputKey2.value = '';
    }
    const outputText = document.getElementById('source-text');
    if (outputText !== null) {
        outputText.value = '';
    }
}

// handlers
function handleFile(event) {
    const reader = new FileReader();
    reader.onload = function(e) {
        document.getElementById('source-text').value = e.target.result;
    };
    reader.readAsText(event.target.files[0]);
    // Сбрасываем значение инпута файла, чтобы сработал повторный выбор
    event.target.value = '';
    Reset(true);
}

function handleDropdown() {
    const dropdown = document.getElementById('dropdown');
    const inputsBox = document.getElementsByClassName('inputs-box')[0];
    const cryptoCodeInfo = document.getElementById('crypto-code-info');

    // if vigener-cipher => two keys, add second if wasn't
    if (dropdown.value === "vigener-cipher") {
        const inputKey2 = document.getElementById('input-key2');
        if (inputKey2 !== null) {
            inputsBox.removeChild(inputKey2);
        }
        const labelKey2 = document.getElementById('label-key2');
        if (labelKey2 !== null) {
            inputsBox.removeChild(labelKey2);
        }
        cryptoCodeInfo.innerText = "Выбранный алгоритм:  Алгоритм Виженера (самогенерирующийся ключ)";
    }
    // if one key, check if there is 2 input and remove it with label
    else if (dropdown.value === "column-method") {
        const inputKey2 = document.getElementById('input-key2');
        if (inputKey2 === null) {
            // input 2
            const inputKey2 = document.createElement('input');
            inputKey2.type = 'text';
            inputKey2.id = "input-key2";
            inputKey2.placeholder = 'введите ключ 2';
            // label 2
            const labelKey2 = document.createElement('label');
            labelKey2.htmlFor = "input-key2";
            labelKey2.id = "label-key2";
            labelKey2.textContent = "Ключ №2";

            inputsBox.appendChild(labelKey2);
            inputsBox.appendChild(inputKey2);
        }
        cryptoCodeInfo.innerText = "Выбранный алгоритм: Столбцовый метод (с двумя ключевыми словами)";
    }
    Reset();
}

function getCorrectKey(key) {
    let result = "";
    for (let i = 0; i < key.length; i++) {
        if (ord(key[i]) !== -1) {
            result += key[i];
        }
    }
    return result;
}

function encryptText() {
    const inputText = document.getElementById('source-text').value;
    const dropdown = document.getElementById('dropdown');
    const inputKey = document.getElementById('input-key1');
    const key = getCorrectKey(inputKey.value);
    inputKey.value = key;
    if (key === "") {
        alert("Ошибка!!!\nКлюч полностью не корректный!");
        return;
    }
    let result = "";
    if (dropdown.value === "column-method") {
        const inputKey2 = document.getElementById('input-key2');
        const key2 = getCorrectKey(inputKey2.value);
        inputKey2.value = key2;
        if (key2 === "") {
            alert("Ошибка!!!\nКлюч(и) полностью не корректный!");
            return;
        }
        result = columnsMethod(key, key2, inputText, true);
    }
    if (dropdown.value === "vigener-cipher") {
        result = vigenerCipher(key, inputText, true);
    }

    document.getElementById('resultText').value = result;
}

function decryptText() {
    const inputText = document.getElementById('source-text').value;
    const dropdown = document.getElementById('dropdown');
    const inputKey = document.getElementById('input-key1');
    const key = getCorrectKey(inputKey.value);
    inputKey.value = key;
    console.log(inputKey.value, key);
    if (key === "") {
        alert("Ошибка!!!\nКлюч полностью не корректный!");
        return;
    }
    let result = "";
    if (dropdown.value === "column-method") {
        const inputKey2 = document.getElementById('input-key2');
        const key2 = getCorrectKey(inputKey2.value);
        inputKey2.value = key2;
        if (key2 === "") {
            alert("Ошибка!!!\nКлюч(и) полностью не корректный!");
            return;
        }
        result = columnsMethod(key, key2, inputText, false);
    }
    if (dropdown.value === "vigener-cipher") {
        result = vigenerCipher(key, inputText, false);
    }

    document.getElementById('resultText').value = result;
}

const alphabet = 'АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ';

// Получаем порядковый номер буквы
function ord(char) {
    return alphabet.indexOf(char.toUpperCase());
}

// Получаем букву по порядковому номеру
function char(number) {
    const idx = ((number % alphabet.length) + alphabet.length) % alphabet.length;
    return alphabet[idx];
}

// Шифрование и дешифрование Виженера
function vigenerCipher(key, text, isEncrypt) {

    function EncryptVigener(key, text) {
        let result = '';
        let j = 0;

        for (let i = 0; i < text.length; i++) {
            const currentChar = text[i];
            let curCharNum = 0;
            // если не символ алфавита пропускаем итерацию
            if (ord(currentChar) === -1) {
                result += currentChar;
                continue;
            }
            // итерируемся по ключевому слову
            if (j < key.length) {
                curCharNum = (ord(currentChar) + ord(key[j])) % alphabet.length;
                j++;
            }
            // итерируемся по исходному тексту слову
            else {
                while (j - key.length >= 0 && (!isNaN(parseInt(text[j - key.length])) || text[j - key.length] === ' ')) {
                    j++;
                }
                curCharNum = (ord(currentChar) + ord(text[j - key.length])) % alphabet.length;
                j++;
            }
            result += char(curCharNum);
        }
        return result;
    }

    function DecryptVigener(key, text) {
        let result = '';
        let j = 0;

        for (let i = 0; i < text.length; i++) {
            const currentChar = text[i];
            let curCharNum;
            // если не символ алфавита пропускаем итерацию
            if (ord(currentChar) === -1) {
                result += currentChar;
                continue;
            }

            if (j < key.length) {
                curCharNum = (ord(currentChar) - ord(key[j]) + alphabet.length) % alphabet.length;
                j++;
            } else {
                while (j - key.length >= 0 && (!isNaN(parseInt(result[j - key.length])) || result[j - key.length] === ' ')) {
                    j++;
                }
                curCharNum = (ord(currentChar) - ord(result[j - key.length]) + alphabet.length) % alphabet.length;
                j++;
            }
            result += char(curCharNum);
        }
        return result;
    }

    return isEncrypt ? EncryptVigener(key, text) : DecryptVigener(key, text);
}

// Шифрование и дешифрование методом столбцов
function columnsMethod(key, key2, text, isEncrypt) {
    function formTextArray(size, text, key, index) {
        let textLetters = new Array(size);
        let j = 0;
        for (let i = 0; i < size; i++) {
            // заполняем символами
            if (index + j < text.length) {
                textLetters[i] = text[index + j];
            }
            // заполняем пустоту
            else {
                textLetters[i] = ' ';
            }
            j += key.length;
        }
        return textLetters;
    }

    function EncryptColumns(key, text) {
        const columns = [];
        const n = Math.ceil(text.length / key.length);
        for (let i = 0; i < key.length; i++) {
            const textLetters = formTextArray(n, text, key, i);
            columns.push({
                key: key[i],
                sortIndex: -1,
                textLetters
            });
        }
        // сортируем ключевое слов
        const sortedLetters = key.split('').sort(
            (a, b) => {
                return ord(a) - ord(b);
            });
        console.log(sortedLetters);
        //
        let result = "";
        // переносим индекс в столбцы
        for (let i = 0; i < sortedLetters.length; i++) {
            const column = columns.find((column) => column.key === sortedLetters[i] && column.sortIndex === -1);
            column.sortIndex = i;
            result += column.textLetters.join('');
            console.log(i, result);
        }
        return result;
    }

    function DecryptColumns(key, text) {
        const columns = [];
        const n = Math.ceil(text.length / key.length);
        for (let i = 0; i < key.length; i++) {
            columns.push({
                key: key[i],
                sortIndex: -1,
                textLetters: []
            });
        }
        // сортируем ключевое слов
        const sortedLetters = key.split('').sort(
            (a, b) => {
                return ord(a) - ord(b);
            });
        // востанавливаем состояние столбцов как было до шифрования
        let j = 0;
        for (let i = 0; i < sortedLetters.length; i++) {
            // получаем кусок строки в виде массива
            const textLetters = text.substring(Math.min(j, text.length), Math.min(j + n, text.length)).split('');
            // если не хватило символов из строки добавляем пробелы
            while (textLetters.length < n) {
                textLetters.push(' ');
            }
            j += n;
            // определяем где он был до этого
            const column = columns.find((column) => column.key === sortedLetters[i] && column.sortIndex === -1);
            column.sortIndex = i;
            column.textLetters = textLetters;
            console.log(i, column.textLetters);
        }
        // востанавливаем исходную строку
        let result = "";
        for (let i = 0; i < n; i++) {
            columns.forEach((column) => result += column.textLetters[i]);
        }
        return result;
    }


    return isEncrypt ?
        EncryptColumns(key2, EncryptColumns(key, text).trim()).trim() :
        DecryptColumns(key2, DecryptColumns(key, text).trim()).trim();
}