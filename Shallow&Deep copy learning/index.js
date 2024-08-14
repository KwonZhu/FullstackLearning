// Shallow Copy Example
let product = {
  id: 1,
  name: 'Smartphone',
  price: 499.99,
  details: {
    brand: 'TechCo',
    model: 'SmartX1',
    specifications: {
      display: '6.2 inches',
      camera: '12 MP',
      storage: '64 GB',
    },
  },
};

// Shallow copy using the spread operator
let copiedProduct = { ...product };

copiedProduct.name = 'Smartwatch'; // Disconnected

// Changes in the nested object are connected
copiedProduct.details.model = 'WatchPro';
copiedProduct.details.specifications.display = '1.3 inches';

console.log('Shallow Copy - Copied Product:', copiedProduct);
console.log('Shallow Copy - Original Product:', product);

// Deep Copy Example
let productDeep = {
  id: 1,
  name: 'Smartphone',
  price: 499.99,
  details: {
    brand: 'TechCo',
    model: 'SmartX1',
    specifications: {
      display: '6.2 inches',
      camera: '12 MP',
      storage: '64 GB',
    },
  },
};

// Deep copy using JSON methods
let copiedProductDeep = JSON.parse(JSON.stringify(productDeep));

copiedProductDeep.name = 'Laptop'; // Disconnected

// Changes in the nested object are also disconnected
copiedProductDeep.details.model = 'LaptopPro';
copiedProductDeep.details.specifications.display = '15.6 inches';

console.log('Deep Copy - Copied Product:', copiedProductDeep);
console.log('Deep Copy - Original Product:', productDeep);

// concise example => Object.assign()
let o1 = { a: { b: 1 }, c: 1 };
let obj = Object.assign({}, o1);

o1.a.b = 3;
o1.c = 4;

console.log('o1:', o1); // o1: { a: { b: 3 }, c: 4 }
console.log('obj', obj); // obj { a: { b: 3 }, c: 1 }

// concise example => Spread Operator ...
let oldObj = { a: { b: 10 }, c: 2 };
let newObj = { ...oldObj };

oldObj.a.b = 2;
oldObj.c = 5;

console.log('oldObj:', oldObj); //oldObj: { a: { b: 2 }, c: 5 }
console.log('newObj:', newObj); //newObj: { a: { b: 2 }, c: 2 }

// concise example => JSON.parse(JSON.stringify())
let originalObject = { a: { b: 10 }, c: 2 };
let deepObj = JSON.parse(JSON.stringify(originalObject));

originalObject.a.b = 3;
originalObject.c = 4;

console.log('originalObj', originalObject); //originalObj { a: { b: 3 }, c: 4 }
console.log('deepObj', deepObj); //deepObj { a: { b: 10 }, c: 2 }

//deep copy => structuredClone()
let john = {
  name: 'John',
  age: 30,
  hobbies: ['reading', 'hiking'],
  address: {
    city: 'New York',
    country: 'USA',
  },
};

// Create a deep copy of the original object
let clonedJohn = structuredClone(john);

john.address.city = 'LA';
john.age = 35;

console.log('clonedJohn:', clonedJohn);
