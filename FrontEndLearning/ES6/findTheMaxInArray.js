const input = [1, 5, 3, 6, 2, 9, 4]; //expect output 9

//version1
const maxValue1 = Math.max(...input);
console.log(maxValue1);

//version2
function findMaxValue(array) {
  let maxValue2 = 0;
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    if (element > maxValue2) {
      maxValue2 = element;
    }
  }
  return maxValue2;
}
console.log(findMaxValue(input));

// version3
const findMax = input.reduce((accumulator, current) => (current > accumulator ? current : accumulator));
console.log(findMax);
