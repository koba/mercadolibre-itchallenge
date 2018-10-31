const fs = require('fs');
const combinatorics = require('js-combinatorics');

const f = fs.readFileSync('./shuffled_images/4894.pgm').toString();

var arr = f.split('\n').slice(2).map(i => parseInt(i, 10));
var chunks = [];

for (var i = 0; i < arr.length; i += 4) {
    chunks.push(arr.slice(i, i + 4));
}

var id = 0;
var keys = [];
for (var i = 0; i < chunks.length; i++) keys.push(i);
var comb = combinatorics.permutation(keys);

while (cmb = comb.next()) {
    var new_chunks = '';
    for (var i = 0; i < cmb.length; i++) {
        new_chunks += chunks[i].join('\n') + '\n';
    }
    fs.writeFileSync('test_images/' + id + '.md', cmb.join(', '));
    fs.writeFileSync('test_images/' + id + '.pgm', 'P2\n64 64\n'+new_chunks);
    id++;
}

console.log(chunks);