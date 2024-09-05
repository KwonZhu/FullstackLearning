'use strict';
function add(a, b) {
  return a + b;
}
const result = add(5, 10);
console.log(result);
const someone = {
  name: 'John',
  age: 10,
};
function greet(person) {
  const { name, age } = person;
  console.log(`Hello ${name}, you are ${age} years old.`);
}
greet(someone);
