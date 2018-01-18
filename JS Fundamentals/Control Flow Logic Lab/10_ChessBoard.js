function chessBoard(n) {
    let result = '<div class="chessboard">\n';
    for (let i = 0; i < n; i++) {
        result += "  <div>\n"
        let color = (i % 2 == 0) ? 'black' : 'white';
        for (let j = 0; j < n; j++) {
            result += `    <span class="${color}"></span>\n`;
            color = (color == 'white') ? 'black' : 'white';
        }
        result += "  </div>\n";
    }
    result += "</div>";

    return result;
}

// console.log(chessBoard(2));