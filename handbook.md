mysql 8.0
.Net Core 8 runtime









折叠所有 Ctrl+K+0

展开所有 Ctrl+K+J

仅仅操作光标所处代码块内的代码： 

折叠 Ctrl+Shift+[

展开 Ctrl+Shift+]


@inject NavigationManager NavigationManager;
<!-- #region initialization -->
@code{
    
    public static HttpClient httpclient =new(){
        BaseAddress=new Uri("http://localhost:5198/"),
    };

    static string Serialize(string[] source) => 
        System.Net.WebUtility.UrlEncode(System.Text.Json.JsonSerializer.Serialize(source));

    DepartmentController dpc=new(httpclient);
    DaoController Dc=new(httpclient);
    String errormsg = "";
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await GetAllDept();
            //StateHasChanged();
        }
        await
        base.OnAfterRenderAsync(firstRender);
    }
    int SearchId;
    List<Department>? DeptDataList;
    //List<int> select
    List<Person> PersonDataList=[];
    Person tempPerson=new();
}
<!-- #endregion initialization -->

<!-- #region other -->
@* <ListComponent Name="FoodList!" Data="" ItemType="">

</ListComponent> *@


@* <ListComponent Name="Weather List" Data="forecasts" ItemType="WeatherForecast">
<HeadTemplet>
<th>Date</th>
<th>Temp. (C)</th>
<th>Temp. (F)</th>
<th>Summary</th>
</HeadTemplet>
<RowTemplet>
<td>@context.Date</td>
<td>@context.TemperatureC</td>
<td>@context.TemperatureF</td>
<td>@context.Summary</td>
</RowTemplet>
<ContentTemplet>
@displayPass

@context
@forecasts!.Count()
</ContentTemplet>
</ListComponent>

<RenderTest />
<PasswordEntry @bind-inerpassword=displayPass />
*@



@*
<input type="text" @bind=Context @oninput=input />
<br>
@Context
@code{
String Context="What is Your Day?";
void input(ChangeEventArgs e){
Context=e.Value!.ToString()+",";
}
*@

@* @if(DataList is null){
<p>loading...</p>
}else{
@DataList;
}

@onclick="@(e => total = number1 + number2)"

*@


@*
<EditForm Model="selectedIdList">
<InputCheckbox>
</InputCheckbox>
</EditForm>
*@


<!-- #endregion -->

<!-- #region errmsg -->
@if (errormsg.Any())
{
    //=new DateTime(2023,12,8,16,30,00);
    //"2023/12/6 18:30:00";
    errormsg+=DateTime.Now.ToShortDateString();
    <div>
        <p class=" bg-danger text-warning  p-3  w-70   ">@errormsg</p>
        <button @onclick="@(e=> errormsg="")" class=" btn-close "></button>
    </div>
}
<!-- #endregion errmsg -->
select department by Id:
<input type="number" @bind=SearchId>
<button @onclick=GetDeptById class="btn-primary">GetData</button>
<br>

<!-- #region Department code-->
<div class="DepartmentList ">
    @if(DeptDataList is null||DeptDataList.Count==0){
        <p>Null Or Loding...</p>
    }else{
    <ListComponent Name="Department" ItemType="Department" DataList="DeptDataList">

        <HeadTemplet>
            <th>OrderNumber</th>
            <th>Id</th>
            <th>Name</th>
            <th>Operation
                <button @onclick=GetAllDept class=" btn-success ">RefreshDept</button>
                <button @onclick=UpdateDepartment class="btn-secondary">Update</button>
                @* @{
                bool notContains =false;

                if(selectedIdList is not null){
                notContains=!selectedIdList.Any();
                return;
                }

                disabled=@notContains
                } *@
                <button @onclick=DeleteDepartment class="btn-danger">Delete</button>

            </th>
            <br>

        </HeadTemplet>
        <RowTemplet>
            <td></td>
            <td>@context.Id</td>
            <td><input @bind-value=@context.Name></td>
            <td>
                @{
                    void select()
                    {

                        if (selectedIdList!.Contains(context.Id))
                        {
                            selectedIdList.Remove(context.Id);
                            return;
                        }
                        selectedIdList.Add(context.Id);
                    }
                }
                <input type="checkbox" @onclick=select />
                @* <button class=" disabled " disabled="true" @onclick="@(
                e=> dpc.DeleteAsync(context.Id)
                )">Delete</button> *@
            </td>
        </RowTemplet>
        <ContentTemplet>

            <p>TotalNumber:@DeptDataList!.Count();</p>

            <td><input type="number" @bind=dept!.Id class=" input-group-text"></td>

            <td><input type="text" @bind=dept.Name class=" input-group-text"></td>

            <button @onclick=addDepartment disabled=@isSubmitting class=" btn-primary">Add a NewDepartment</button>
        </ContentTemplet>
    </ListComponent>
    }
</div>

<hr>
<!-- dept code-->
@code {
    //String? displayPass="未输入";
    //以下的方法都可以变成模板，都可以重复使用，需要封装到方法里？
    //错误提示信息

    async Task GetDeptById()
    {   //var x = await dpc.GetByIdAsync(SearchId);
       // List<Department> a = await dpc.GetByIdAsync(SearchId);
        List<Department>? a= await dpc.GetByIdAsync(SearchId);
        if (a is null)
        {
            Console.WriteLine("cant get datalist all,may time out or null database;");
            return;
        }
        DeptDataList = a;
        SearchId=0;
        StateHasChanged();
    }

    async Task GetAllDept()
    {
        var a = await dpc.GetAllAsync();
        if (a is null)
        {
            Console.WriteLine("cant get datalist all,may time out or null database;");
            return;
        }
        DeptDataList = a;
        StateHasChanged();
    }
    bool isSubmitting = false;
    Department? dept = new();
    //[System.ComponentModel.DataAnnotations.Required]
    //int newId;
    //String newName="newDepartmentName";
    async Task addDepartment()
    {
        if (dept is null)
        {
            Console.WriteLine("Input value is null please reEnter");
            return;
        }
        isSubmitting = true;
        await dpc.AddAsync(dept);
        Thread.Sleep(1000);
        isSubmitting = false;
        //await GetAllDept();
        NavigationManager.NavigateTo("/", true);//refresh
    }

    async Task UpdateDepartment()
    {
        await dpc.UpdateAsync(DeptDataList!);

    }
    List<int>? selectedIdList = new();

    async Task DeleteDepartment()
    {
        //如果没有被选中 不应该让按钮生效
        if (selectedIdList is null)
        {
            Console.WriteLine("cant null delete");
            errormsg += "cant null delete";
            return;
        }

        if (!selectedIdList.Any())
        {
            Console.WriteLine("cant null delete");
            errormsg += "cant null delete";
            return;
        }

        foreach (var i in selectedIdList)
        {
            Console.WriteLine(i.ToString());
        }
        @* return; *@
        await dpc.DeleteAsync(selectedIdList);
        selectedIdList = new();
        //await GetAllDept();
        NavigationManager.NavigateTo("/", true);//refresh
                                                //StateHasChanged();
    }

    @* void UpdateDepartment(){

//await dpc.UpdateAsync(DataList!);
//Console.WriteLine("Keypress");
//await dpc.Update(DataList);
} *@

}
<!-- #endregion Department code-->

<!-- #region list code for person-->


    select Person Property by Id:
<input type="number" @bind=SearchId>
<button @onclick="GetOwnDeptAsync" class="btn-primary">GetDeptData</button>
<button @onclick="GetOwnCourseOrDefault" class="btn-primary">GetCourseData</button>
<br>

@if(PersonDataList.Any()){
//Console.WriteLine("PersonListNotNull");
<div class="PersonLIst">

@code{
    int Pnumber =0;
}
    <ListComponent Name="Persons" ItemType="Person" DataList="PersonDataList">

        <HeadTemplet>
            
            <th>OrderNumber</th>
            <th>Id</th>
            <th>Name</th>
            <th>Department</th>
            <th>Class</th>
            <th>Operation
                <button @onclick=GetAllPersonAsync class=" btn-success ">RefreshDept</button>
                @* <button @onclick=UpdateDepartment class="btn-secondary">Update</button> *@
                @* <button @onclick=DeleteDepartment class="btn-danger">Delete</button> *@
            </th>
            <br>

        </HeadTemplet>
        <RowTemplet>
            @{var Pnumber = context.GetHashCode();}
            <td>@Pnumber</td>
            <td>@context.Id</td>
        @if(true){
            <td>@context.Name</td>
        }else{
            @* <td><input @bind-value=@context.Name></td> *@
        }

            @{//这真的能用吗？取不到dept context.Departments.FirstOrDefault()
            
                string alldeptstr="类别：";
                if(context.Departments.Any()){
                    foreach(var item in context.Departments ){
                    alldeptstr+=item;
                    }
                }else{
                    alldeptstr+="空";
                }



            }
            <td>@alldeptstr</td>

            <td>
                @* @{
                    void select()
                    {

                        if (selectedIdList!.Contains(context.Id))
                        {
                            selectedIdList.Remove(context.Id);
                            return;
                        }
                        selectedIdList.Add(context.Id);
                    }//@onclick=select
                } *@
                <input type="checkbox"  />
            </td>

        </RowTemplet>
        <ContentTemplet>

            <p>TotalNumber:@PersonDataList!.Count();</p>

            <td><input type="number" @bind=tempPerson!.Id class=" input-group-text"></td>
            <td><input type="text" @bind=tempPerson.Name class=" input-group-text"></td>
            @* <td><input type="text" @bind=tempPerson.Departments class=" input-group-text"></td> *@
            <td><button>add dept</button></td>
            @* <button @onclick=addPerson disabled=@isSubmitting class=" btn-primary">Add a Person</button> *@
        </ContentTemplet>
    </ListComponent>
</div>


}else{
    <br>
<button @onclick=GetAllPersonAsync class=" btn-success ">GetAllPerson</button>
}

<!-- #endregion -->

<!-- #region person code-->
@using Controller;
@code{

    async Task GetAllPersonAsync()
    {
        var a = await Dc.GetAllAsync<Person>("Persons");
        if (a is null)
        {
            Console.WriteLine("cant get datalist all,may time out or null database;");
            return;
        }
        PersonDataList = a;
        StateHasChanged();
    }

    async Task GetOwnDeptAsync(){
        DeptDataList=await Dc.GetOwnPropertyAsync<Department>("Persons/Departments/",SearchId);
            SearchId=0;
    }
    List<Course>? CourseDataList =[];
    void GetOwnCourseOrDefault(){
        
            //string[] ;
            //public string[] paramstr => Serialize(CourseDataList); 


            NavigationManager.NavigateTo("/StudentCourse/"+SearchId);
            SearchId=0;
            // return;
            //https://stackoverflow.com/questions/65644327/how-to-pass-a-list-as-a-parameter-to-blazor-page
            //https://blog.csdn.net/WarGames_dc/article/details/106213300
    }


    
}
<!-- #endregion person code-->



<!-- #region other-->

@code {

    //persons = await HttpClient.GetFromJsonAsync<List<Person>>(NavigationManager.BaseUri + "persons"+"/"+"?id="+id);
    //await HttpClient.PostAsJsonAsync($"{NavigationManager.BaseUri}persons", person);

    @*
Department[]? DataArray;
async void GetDataArray(){
DataArray=await HttpClient.GetFromJsonAsync<Department[]?>(NavigationManager.BaseUri + "Departments"+"/"+"?id="+id);
StateHasChanged();
}
private List<WeatherForecast>? forecasts;
protected override async Task OnInitializedAsync()
{
//forecasts = await ForecastService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
}
*@
}
<!-- #endregion -->