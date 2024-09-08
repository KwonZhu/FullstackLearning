function add(a: number, b: number): number{
  return a + b;
}
const result: number = add(5,10);
console.log(result);


interface Person {
  name: string;
  age: number;
}
const someone: Person = {
  name: 'John',
  age: 10
};
function greet(person: Person) : void{
  const {name, age} = person;
  console.log(`Hello ${name}, you are ${age} years old.`);
}
greet(someone);