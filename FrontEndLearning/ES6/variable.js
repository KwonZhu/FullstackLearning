// 1. var
var x = 10;
console.log('var x', x); //10
if (true) {
  var x = 20;
  console.log('var x inside', x); //20
}
console.log('var x outside', x); //20

// 2. let => block scope
let y = 10;
console.log('let', y); //10
if (true) {
  let y = 20;
  console.log('let inside', y); //20
}
console.log('let outside', y); //10
y = 30; //allow to reassign

// 3. const
const z = 10;
console.log('const', z); //10
if (true) {
  const z = 20;
  console.log('const inside', z); //20
}
console.log('const outside', z); //10

try {
  z = 30;
} catch (e) {
  console.log('Error', e.message); //Error Assignment to constant variable.
}
