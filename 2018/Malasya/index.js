const fs = require('fs');
const libxmljs = require('libxmljs');
const sha = require('js-sha256');

let output = [];

for (var z = 1; z <= 15; z++) {

    const fileContents = fs.readFileSync('./inputs/input-' + ('00' + z).slice(-2) + '.hrml').toString();
    const lines = fileContents.split('\n');
    const n = parseInt(lines[0].split(' ')[0]);
    const q = parseInt(lines[0].split(' ')[1]);

    const xmlString = lines.slice(1, 1 + n).join('\n');
    const xml = libxmljs.parseXmlString('<?xml version="1.0" encoding="UTF-8"?><root>\n' + xmlString + '</root>');

    for (let i = 0; i < q; i++) {
        const query = lines[1 + n + i];
        const tagTree = query.split('.');
        let obj = xml.root();
        for (let j = 0; j < tagTree.length; j++) {
            let tag = tagTree[j].split('~');
            obj = obj.childNodes().find(child => child.name() == tag[0]);

            if (!obj) {
                output.push('Not Found!');
                break;
            }

            if (tag[1]) {
                let attr = obj.attr(tag[1]);
                if (attr) {
                    output.push(attr.value());
                }
                else {
                    output.push('Not Found!');
                }
            }
        }
    }

}

console.log(sha.sha256(output.join('\n')+'\n').toUpperCase());