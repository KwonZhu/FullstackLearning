// Object
const person = {
  name: 'John',
  age: 18,
  location: {
    city: 'Melbourne',
    country: 'Australia',
  },
};

// Array
const fruit = ['apple', 'orange', 'pear'];

// person name
console.log('person name', person.name);
// person age
console.log('person age', person.age);

// destructuring v1
const { name, age, location } = person;
console.log('destructed name', name);
console.log('location', location);

// destructuring v2
// const {
//   name: myName,
//   age: myAge,
//   location: { city },
// } = person;
// console.log('destructed name', myName);
// try {
//   console.log('location', location); //location is not defined
// } catch (e) {
//   console.log('Error', e.message);
// }
// console.log('destructed city', city);
