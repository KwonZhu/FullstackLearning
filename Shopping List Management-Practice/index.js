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

let shoppingList = [];

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
