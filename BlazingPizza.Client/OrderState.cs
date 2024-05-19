using BlazingPizza;

public class OrderState
{
    public bool showingConfigureDialog { get; private set; }
    public Pizza? ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        showingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        showingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza is not null)
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;
        }
        showingConfigureDialog = false;
    }
    public void ResetOrder()
    {
        Order = new Order();
    }
    public void RemoveCongifuredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    public void ReplaceOrder(Order order)
    {
        Order = order;
    }
}