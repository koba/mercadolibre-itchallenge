const fs = require('fs');

const xorCrypt = function (input, key) {
    var output = new Uint8Array(input.length);

    for (var i = 0; i < input.length; ++i) {
        output[i] = key ^ input[i];
    }

    return output;
}

const encrypted = fs.readFileSync('./secreto.pdf');

if (!fs.existsSync('./output')) {
    fs.mkdirSync('./output');
}

for (var i = 0; i <= 255; i++) {
    var decrypted = xorCrypt(encrypted, i);
    fs.writeFileSync(`./output/${i}.pdf`, decrypted);
}
