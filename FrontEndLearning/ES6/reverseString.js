const input = 'John'; //expect output 'nhoJ'

// version 1
function reverseString1(str) {
  let arr = [];
  str.split('').forEach((char) => arr.unshift(char));
  return arr.join('');
}
console.log(reverseString1(input));

// version 2
function reverseString2(str) {
  return str.split('').reverse().join('');
}
console.log(reverseString2(input));

// version 3
function reverseString3(str) {
  let newString = '';
  for (let i = str.length - 1; i >= 0; i--) {
    newString += str[i];
  }
  return newString;
}
console.log(reverseString3(input));
