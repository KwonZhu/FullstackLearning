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
