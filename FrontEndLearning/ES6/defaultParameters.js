// function without default parameters
function greetWithoutDefaultParam(name) {
  return `Hello, ${name}`;
}
console.log('without default parameters', greetWithoutDefaultParam());
console.log('without default parameters', greetWithoutDefaultParam('Jade'));

// function with default parameters
function greetWithDefaultParam(name = 'Guest') {
  return `Hello, ${name}`;
}
console.log('with default parameters', greetWithDefaultParam());
console.log('with default parameters', greetWithDefaultParam('Jade'));
