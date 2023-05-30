namespace StudentExerciseMVC_API.Models
{
  public class CoctailViewModel
  {
      public string strDrink { get; set; }
      public string strDrinkThumb { get; set; }
      public string idDrink { get; set; }
    

    public class Root
    {
      public List<CoctailViewModel> drinks { get; set; }
    }


  }
}
