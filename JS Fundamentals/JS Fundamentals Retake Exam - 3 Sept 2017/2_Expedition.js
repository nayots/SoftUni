//FUCK THIS SHIT!

// function expedition(maze, overlay, coordinates, startRC) {
//     function isWithin(r, c) {
//         return ((r < maze.length && r >= 0) && (c < maze[0].length && c > 0));
//     }

//     function printMatrix(matrix) {
//         matrix.forEach(row => {
//             console.log(row.join("   "));
//         });
//     }

//     function canStep(r, c) {
//         let stepedBefore = stepsTaken.filter(s => (s[0] === r && s[1] === c)).length > 0;
//         if (isWithin(r, c) && maze[r][c] === 0 && (r !== startRC[0] || c !== startRC[1]) && !stepedBefore) {
//             return true;
//         } else {
//             return false;
//         }
//     }

//     function isWinner(r, c) {
//         if (isWithin(r, c) && ((r === 0 || r === maze.length - 1) || (c === 0 || c === maze[0].length - 1)) && (r !== startRC[0] || c !== startRC[1])) {
//             return true;
//         } else {
//             return false;
//         }
//     }

//     coordinates.forEach(crd => {
//         let [r, c] = crd.map(Number);
//         if (isWithin(r, c)) {
//             for (let row = 0; row < overlay.length; row++) {
//                 for (let col = 0; col < overlay[row].length; col++) {
//                     let element = overlay[row][col];
//                     let realR = r + row;
//                     let realC = c + col;
//                     if (isWithin(realR, realC) && isWithin(realR, realC) && element !== 0) {
//                         let eleAtMaze = maze[realR][realC];
//                         eleAtMaze === 1 ? maze[realR][realC] = 0 : maze[realR][realC] = 1;
//                     }
//                 }
//             }
//         }
//     });

//     let step1 = {};
//     step1.num = 1;
//     step1.rc = startRC;

//     let steps = [step1];
//     let stepsTaken = [];
//     let cStep = step1;

//     while (steps.length > 0) {
//         let current = steps.shift();
//         cStep = current;
//         let cR = current.rc[0];
//         let cC = current.rc[1];
//         stepsTaken.push(current.rc);
//         if (isWinner(cR, cC)) {
//             console.log(current.num)
//             break;
//         }
//         if (canStep(cR - 1, cC)) { //UP
//             steps.push({
//                 num: current.num + 1,
//                 rc: [cR - 1, cC]
//             })
//         }

//         if (canStep(cR + 1, cC)) { //DOWN
//             steps.push({
//                 num: current.num + 1,
//                 rc: [cR + 1, cC]
//             })
//         }

//         if (canStep(cR, cC - 1)) { //LEFT
//             steps.push({
//                 num: current.num + 1,
//                 rc: [cR, cC - 1]
//             })
//         }

//         if (canStep(cR, cC + 1)) { //RIGHT
//             steps.push({
//                 num: current.num + 1,
//                 rc: [cR, cC + 1]
//             })
//         }
//     }

//     let primaryMatrixRows = maze.length;
//     let primaryMatrixCols = maze[0].length;

//     function definePosition(currentPosition) {
//         let currentRow = currentPosition[0];
//         let currentCol = currentPosition[1];
//         if (currentRow == 0) {
//             console.log("Top");
//         } else if (currentRow == primaryMatrixRows - 1) {
//             console.log("Bottom");
//         } else if (currentCol == 0) {
//             console.log("Left");
//         } else if (currentCol == primaryMatrixCols - 1) {
//             console.log("Right");
//         } else if (currentRow < primaryMatrixRows / 2 && currentCol >= primaryMatrixCols / 2) {
//             console.log("Dead end 1");
//         } else if (currentRow < primaryMatrixRows / 2 && currentCol < primaryMatrixCols / 2) {
//             console.log("Dead end 2");
//         } else if (currentRow >= primaryMatrixRows / 2 && currentCol < primaryMatrixCols / 2) {
//             console.log("Dead end 3");
//         } else if (currentRow >= primaryMatrixRows / 2 && currentCol >= primaryMatrixCols / 2) {
//             console.log("Dead end 4");
//         }
//     }

//     definePosition(cStep.rc);


//     // printMatrix(maze);
// }

// expedition([
//     [1, 1, 0, 1, 1, 1, 1, 0],
//     [0, 1, 1, 1, 0, 0, 0, 1],
//     [1, 0, 0, 1, 0, 0, 0, 1],
//     [0, 0, 0, 1, 1, 0, 0, 1],
//     [1, 0, 0, 1, 1, 1, 1, 1],
//     [1, 0, 1, 1, 0, 1, 0, 0]
// ], [
//     [0, 1, 1],
//     [0, 1, 0],
//     [1, 1, 0]
// ], [
//     [1, 1],
//     [2, 3],
//     [5, 3]
// ], [0, 2]);