# CRUDtest
 asp.net core mvc & Rest CRUD



<h3>Description</h3>


Application utilizes two varieties of access to the CRUD interface.

First through a UI created with the .Net Core MVC and second through `HTTP` request methods with an `api/products/{id?}` endpoint.
As per direction, `POST` & `PUT` methods store a timestamp generated by the client together with the user who created/edited the content. And the create/edit pages are only accessible if a user is loggen in.
When using the api endpoint or third party tools (i.e. Postman) to update the database, the defined user is 'api', as I didn't supply any token verification. Which of course is mandatory in a deployed application. I also did not create a separate view for displaying the stored html because I chose to render/display it in the Entry List.

User registration/authorization uses Microsoft Identity.


<h3>Short Modus Operandi</h3>

I created Model classes for the ProductsContext that is connected to the SQL database and Product defining get/set methods and our entry table. In the ProductController, if request are done through the UI, the `GET` method supplies a list of products. While `GET` with and id routes to the Product Form View, either to edit the entry or create new if no id is given(defaults to 0). `POST` & `PUT` also use one method with a conditioner and should not yield any more problems than if they were separated.
The endpoint methods are separated for individual requests and in practice would be used to i.e. supply a JSON object to parties with valid tokens.

To not overcomplicate I chose to edit the `HTML` stored in the Product as a string. This can be further developet to either predefine tags for controlled content or create an advanced editor. The latter, of course, boasts a larger ability to customize the entry.

Dont hesitate to let me know if I should elaborate, edit or add anything!

Have a nice day! =D
