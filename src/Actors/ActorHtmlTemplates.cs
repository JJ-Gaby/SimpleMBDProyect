namespace SimpleMDB;

public class ActorHtmlTemplates
{
   public static string ViewAllActorsGet(List<Actor> actors, int page, int size, int actorCount)
   {
        int pageCount = (int)Math.Ceiling((double)actorCount / size);

        string rows = "";

        foreach (var actor in actors)
        {
            rows += @$"
            <tr>
           <td> {actor.Id} </td>
            <td>{actor.FirstName}</td>
            <td>{actor.LastName}</td>
            <td>{actor.Bio}</td>
            <td>{actor.Rating}</td>
            <td><a href=""/actors/view?aid={actor.Id}"">View</a></td>
            <td><a href=""/actors/edit?aid={actor.Id}"">Edit</a></td>
            <td><a href=""/actors/movies?aid={actor.Id}"">Movies</a></td>
            <td>
            <form action=""/actors/remove?aid={actor.Id}"" method= ""POST"" onsubmit=""return confirm('Are you sure you want to remove this actor?');"">
            <input type= ""submit"" value=""Remove"">
            </form>
            </td>
            </tr>";
        }

        string pDisable = (page > 1).ToString().ToLower();
        string nDisable = (page < pageCount).ToString().ToLower();

        string html = $@"
        <div class=""add"">
            <a href=""/actors/add"">Add New Actor</a>
        </div>
        <table class= ""viewall"">
        <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Bio</th>
                <th>Rating</th>
                <th>View</th>
                <th>Edit</th>
                <th>Remove</th>
            </tr>
        </thead>
        <tbody>
            {rows}
        </tbody>
        </table>
        <div class=""pagination"">
          <a href=""?page=1&size={size}"" onclick=""return {pDisable};"">First</a>
          <a href=""?page={page - 1}&size={size}"" onclick=""return {pDisable};"">Previous</a>
          <span>Page {page} of {pageCount}</span>  
          <a href=""?page={page + 1}&size={size}"" onclick="" return {nDisable};"">Next</a>
          <a href=""?page={pageCount}&size={size}"" onclick="" return {nDisable};"">Last</a>
        </div>
";
return html;
   }

   public static string AddActorGet(string firstname, string lastname, string bio, string rating)
   {
        string html = $@"
        <form class=""addform"" action=""/actors/add"" method=""POST"">
            <label for=""firstname"">First Name</label>
            <input type=""text"" id=""firstname"" name=""firstname"" placeholder= ""First Name"" value =""{firstname}"">
            <label for=""lastname"">Last Name</label>
            <input type=""lastname"" id=""lastname"" name=""lastname"" type=""text"" placeholder= ""Last Name"" value =""{lastname}"">
            <label for=""bio"">Bio</label>
            <input type=""bio"" id=""bio"" name=""bio"" type=""text"" placeholder= ""Bio"" value=""{bio}"">
            <label for=""rating"">Rating</label>
            <input id=""rating"" name=""rating"" type=""number"" min=""0"" max=""10"" step=""0.1"" value =""{rating}"">
            <input type=""submit"" value=""Add"">
        </form>";

        return html;
   } 

   public static string ViewActorGet(Actor actor){
            string html = $@"
        <table class=  ""view"">
        <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Bio</th>
                <th>Rating</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>{actor.Id}</td>
                <td>{actor.FirstName}</td>
                <td>{actor.LastName}</td>
                <td>{actor.Bio}</td>
                <td>{actor.Rating}</td>
            </tr>
        </tbody>
        </table>";
        return html;
   }

   public static string EditActorGet(Actor actor, int aid)
   {
        string html = $@"
        <form class=""editform"" action=""/actors/edit?aid={aid}"" method=""POST"">
            <label for=""firstname"">First Name:</label>
            <input type=""text"" id=""firstname"" name=""firstname"" placeholder= ""First Name"" value =""{actor.FirstName}""><br><br>
            <label for=""lastname"">Last Name:</label>
            <input type=""text"" id=""lastname"" name=""lastname"" placeholder= ""Last Name""value =""{actor.LastName}""><br><br>
            <label for=""bio"">Bio:</label>
            <input type=""text"" id=""bio"" name=""bio"" placeholder= ""Bio"" value =""{actor.Bio}""><br><br>
            <label for=""rating"">Rating:</label>
            <input id=""rating"" name=""rating"" type=""number"" min=""0"" max=""10"" step=""0.1"" value =""{actor.Rating}""><br><br>
            <input type=""submit"" value=""Edit"">
        </form>";
        return html;
   }
}