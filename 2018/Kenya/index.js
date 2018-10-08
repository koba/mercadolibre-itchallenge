let medals = ['abcdefgggghijlmmmnopppqqqqrrr', 'abcdefggghijlmmnopppqqqqrrr', 'abcdefggggghijlmmmnopppqqqqrrr', 'abcdefggggghijlmmmnopppqqqqrrr', 'abcdefggggghijlmmmnopppqqqqrrr'];
let stoness = [];

medals.forEach(medal => {
    let stonesc = {};
    medal.split('').forEach(stone => {
        if (stoness.indexOf(stone) >= 0) return;
        if (!stonesc[stone]) stonesc[stone] = 1; else stonesc[stone]++;
        if (stonesc[stone] > 2) stoness.push(stone);
    });
});

stoness.forEach((stone, i) => {
    medals.forEach(medal => {
        let o = medal.match(new RegExp(stone, 'g'));
        if (!o || o.length <= 2) {
            stoness.splice(i, 1);
        }
    });
});

console.log(stoness.length * stoness.length);
