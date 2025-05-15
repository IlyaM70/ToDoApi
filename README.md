<h1>📝 ToDoApi</h1>
<p>A simple ToDo list API built using ASP.NET Core. This project provides basic CRUD operations for managing tasks.</p>

<h2>🚀 Features</h2>
<ul>
  <li>Create, Read, Update, and Delete (CRUD) operations for ToDo items</li>
  <li>RESTful API endpoints</li>
  <li>Integration with a relational database using Entity Framework Core</li>
</ul>

<h2>🛠️ Technologies Used</h2>
<ul>
  <li>C#</li>
  <li>ASP.NET Core</li>
  <li>Entity Framework Core</li>
  <li>Docker (for containerization)</li>
</ul>

<h2>📥 Installation</h2>
<ol>
  <li><strong>Clone the repository</strong>
    <pre><code>git clone https://github.com/IlyaM70/ToDoApi.git
cd ToDoApi</code></pre>
  </li>
  <li><strong>Build the project</strong>
    <pre><code>dotnet build</code></pre>
  </li>
  <li><strong>Run the application</strong>
    <pre><code>dotnet run</code></pre>
  </li>
</ol>

<h2>💻 Usage</h2>
<p>Once the application is running, you can interact with the ToDo API using tools like Postman or cURL.</p>

<h3>API Endpoints</h3>
<ul>
  <li><code>GET /api/todoitems</code> – Retrieve all ToDo items</li>
  <li><code>GET /api/todoitems/{id}</code> – Retrieve a specific ToDo item by ID</li>
  <li><code>POST /api/todoitems</code> – Create a new ToDo item</li>
  <li><code>PUT /api/todoitems/{id}</code> – Update an existing ToDo item</li>
  <li><code>DELETE /api/todoitems/{id}</code> – Delete a ToDo item</li>
</ul>

<h2>📂 Project Structure</h2>
<pre><code>ToDoApi/
├── ToDoApi/                 # Main API project
├── ToDoApiTests/            # Test project
├── docker-compose.yml       # Docker Compose configuration
├── ToDoApi.sln              # Solution file
└── README.md                # Documentation</code></pre>
