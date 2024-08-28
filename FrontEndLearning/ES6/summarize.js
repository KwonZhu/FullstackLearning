// 1. var
var firstName = 'Alice';
if (true) {
  var firstName = 'Bob';
  console.log(firstName); //Bob //reassign
}
console.log(firstName); //Bob //no block scope

let y = 10;
if (true) {
  let y = 20;
  console.log(y); //20 //new variable
}
console.log(y); //10 //original variable // block scope

const z = 10;
if (true) {
  const z = 20;
  console.log(z); //20 //new variable
}
console.log(z); //10 //original variable // block scope
// z = 30 //Error Assignment to constant variable.

// 2. Arrow Functions
const add = (x, y) => {
  return x + y;
};
// For arrow function, `this` always be fixed to the context in which the function was defined.
// This is especially useful in callback functions where you need access to the parent `this`, such as in event handlers or timer callbacks
// => If the arrow function was defined in the global context, `this` refers to the global object;
//    if it was defined inside an object's method, `this` refers to that object.

// 3. Template Literals
let greeting = 'Hello, ' + firstName + '! Welcome to Australia.';
console.log(greeting);

let message = `Hello, ${firstName}!
Welcome to Australia.`;
console.log(message);

// 4. Destructuring
const person = {
  name: 'John',
  age: 30,
  city: 'Melbourne',
};
const { name, age, city } = person;
console.log(name, age, city);
const details = ({ name, age, city }) => {
  console.log(name, age, city);
};
details(person);

// 5. Default Parameters
function calculateArea(width, height = width) {
  return width * height;
}
console.log('input two parameters', calculateArea(5, 10));
console.log('input one parameter', calculateArea(5));

// 6. Rest/Spread Operators
function summarize(...numbers) {
  return numbers.reduce((acc, curr) => acc + curr);
}
function combine(arr1, arr2) {
  return [...arr1, ...arr2];
}
console.log('summarize 3 numbers', summarize(1, 2, 3));
console.log('summarize 5 numbers', summarize(1, 2, 3, 4, 5));
console.log('summarize 7 numbers', summarize(1, 2, 3, 4, 5, 6, 7));

console.log('combine', combine([1, 2], [3, 4]));
console.log('combine', combine([1, 3, 5], [2, 4, 6]));
