// Rest

// without rest operator
function additionWithoutRest(a, b) {
  return a + b;
}

// with rest operator
function additionWithRest(...numbers) {
  //arr.reduce((previousValue, currentValue) => previousValue + currentValue) return the accumulated sum
  return numbers.reduce((acc, curr) => acc + curr, 0);
}

console.log('additionWithoutRest', additionWithoutRest(2, 2));
console.log('additionWithRest', additionWithRest(1));
console.log('additionWithRest', additionWithRest(1, 2));
console.log('additionWithRest', additionWithRest(1, 2, 3, 4));
console.log('additionWithRest', additionWithRest(1, 2, 3, 4, 5, 6, 7, 8));

// Spread

// without spread operator
function combineWithoutSpread(arr1, arr2) {
  return arr1.concat(arr2);
}

// with spread operator
function combineWithSpread(arr1, arr2) {
  return [...arr1, ...arr2];
}

console.log('combineWithoutSpread', combineWithoutSpread([1, 2], [3, 4]));
console.log('combineWithSpread', combineWithSpread([5, 6], [7, 8]));
