const readline = require('readline');
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let grocery = [
  { name: 'milk', price: 7, quantity: 100 },
  { name: 'egg', price: 8, quantity: 100 },
  { name: 'bread', price: 5, quantity: 100 },
  { name: 'lettuce', price: 4, quantity: 100 },
  { name: 'carrot', price: 2, quantity: 100 },
  { name: 'chicken', price: 10, quantity: 100 },
  { name: 'tissue', price: 4, quantity: 100 },
  { name: 'beef', price: 20, quantity: 100 },
];

let shoppingList = [
  { name: 'onion', price: 2, quantity: 2 },
  { name: 'biscuit', price: 3, quantity: 3 },
];

function showOriginalShoppingList() {
  console.log('Your current cart:');
  shoppingList.forEach((item, index) => {
    console.log(`${index + 1}. ${item.name}: ${item.quantity} item(s)`);
  });
}

function showGroceryList() {
  console.log('\nGrocery List:');
  grocery.forEach((item, index) => {
    console.log(`${index + 1}. ${item.name}  Price: $${item.price}  Available: ${item.quantity}`);
  });
}

function askForInput() {
  rl.question('\nEnter the name of the item would you like to buy: ', (name) => {
    // Based on name, return the first matched item or undefined;
    const item = grocery.find((i) => i.name.toLowerCase() === name.toLowerCase());
    // when the name is available in grocery
    if (item) {
      rl.question(`How many ${item.name} would you like to buy? Available: ${item.quantity}: `, (quantity) => {
        quantity = parseInt(quantity);
        // legal && buyable quantity
        if (!isNaN(quantity) && quantity > 0 && quantity <= item.quantity) {
          shoppingList.push({ name: item.name, price: item.price, quantity: quantity });
          console.log(`Added ${quantity} ${item.name}(s) to your cart.`);
          // update availability
          item.quantity = item.quantity - quantity;
        } else {
          console.log('Invalid quantity.');
        }
        askToContinue();
      });
    } else {
      console.log('Item not found.');
      askToContinue();
    }
  });
}

// add more items or retry when input is illegal
function askToContinue() {
  rl.question('\nWould you like to add another item? (yes/no): ', (answer) => {
    // continue/finish input, show shoppingList at the end
    if (answer.toLowerCase() === 'yes') {
      askForInput();
    } else {
      showShoppingList();
      rl.close();
    }
  });
}

function showShoppingList() {
  console.log('\nYour cart:');
  let total = 0;
  shoppingList.forEach((item, index) => {
    total += item.price * item.quantity;
    console.log(`${index + 1}. ${item.name}: ${item.quantity} item(s)`);
  });
  console.log(`total:  $${total}`);
}

// Start the process
showGroceryList();
showOriginalShoppingList();
askForInput();

/*
function showGrocery() {
  for (let index = 0; index < grocery.length; index++) {
    console.log(index + '. ' + grocery[index].name + ' | price ' + grocery[index].price);
  }
}

showGrocery();

function addToList(goods) {
  if (goods) {
    // when goods goods is valid & in not in shoppingList
    if (shoppingList.findIndex((i) => i === goods) == -1) {
      shoppingList.push(goods);
      return true;
    }
    return console.log(`Sorry, ${goods} is already in shopping cart`);
  }
  return false;
}
addToList('');
addToList('carrot');
addToList('chicken');
addToList('chicken');
console.log(shoppingList);

function deleteGoods() {
  if (shoppingList.length > 0) {
    shoppingList.pop();
  }
}
deleteGoods();
console.log(shoppingList);

function checkShoppingList() {
  if (shoppingList.length > 5) {
    console.log('Sorry, your shopping cart is full');
  }
  for (let index = 0; index < shoppingList.length; index++) {
    console.log(index + 1 + '. ' + shoppingList[index]);
  }
}
checkShoppingList();
*/
