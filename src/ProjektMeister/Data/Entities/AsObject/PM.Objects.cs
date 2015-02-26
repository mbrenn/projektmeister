namespace ProjektMeister.Data.Entities.AsObject
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpSourceFactory", "1.1.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Remark : DatenMeister.IObject, DatenMeister.DataProvider.IProxyObject
    {
        private DatenMeister.IObject obj;
        public Remark(DatenMeister.IObject obj)
        {
            this.obj = obj;
        }

        public static DatenMeister.IObject create(DatenMeister.IFactory factory)
        {
            return factory.create(ProjektMeister.Data.Entities.AsObject.Types.Remark);
        }

        public static Remark createTyped(DatenMeister.IFactory factory)
        {
            return new Remark(create(factory));
        }

        #region IObject Implementation

        public static DatenMeister.IObject create(DatenMeister.IURIExtent extent)
        {
            var factory = DatenMeister.DataProvider.Factory.GetFor(extent);
            return create(factory); 
        }

        /// <summary>
        /// Gets the property by propertyname. 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Retrieved object</returns>
        public DatenMeister.IObject Value
        {
            get { return this.obj; }
        }

        /// <summary>
        /// Gets the property by propertyname. 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Retrieved object</returns>
        public object get(string propertyName, DatenMeister.RequestType requestType = DatenMeister.RequestType.AsDefault)
        {
            return this.obj.get(propertyName, requestType);
        }

        /// <summary>
        /// Gets all properties as key value pairs
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<DatenMeister.ObjectPropertyPair> getAll()
        {
            return this.obj.getAll();
        }

        /// <summary>
        /// Checks, if a certain property is set
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>true, if set</returns>
        public bool isSet(string propertyName)
        {
            return this.obj.isSet(propertyName);
        }

        /// <summary>
        /// Sets the value of the property 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="value">Value to be set</param>
        public void set(string propertyName, object value)
        {
            this.obj.set(propertyName, value);
        }

        /// <summary>
        /// Unsets the property
        /// </summary>
        /// <param name="propertyName">Name of the property to be removed</param>
        public bool unset(string propertyName)
        {
            return this.obj.unset(propertyName);
        }

        /// <summary>
        /// Deletes this object and all composed elements
        /// </summary>
        public void delete()
        {
            this.obj.delete();
        }

        /// <summary>
        /// Gets the id of the object
        /// </summary>
        public string Id
        {
            get
            {
                return this.obj.Id;
            }
        }

		public DatenMeister.IURIExtent Extent
		{
			get
			{
				return this.obj.Extent;
			}
		}

        #endregion

        public System.DateTime getCreated()
        {
            return getCreated(this);
        }

        public void setCreated(System.DateTime value)
        {
            setCreated(this, value);
        }

        public static System.DateTime getCreated(DatenMeister.IObject obj)
        {
            var result = obj.get("created", DatenMeister.RequestType.AsSingle);
            return (result is System.DateTime) ? ((System.DateTime) result) : default(System.DateTime);
        }

        public static void setCreated(DatenMeister.IObject obj, System.DateTime value)
        {
            obj.set("created", value);
        }

        public System.String getAuthor()
        {
            return getAuthor(this);
        }

        public void setAuthor(System.String value)
        {
            setAuthor(this, value);
        }

        public static System.String getAuthor(DatenMeister.IObject obj)
        {
            var result = obj.get("author", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setAuthor(DatenMeister.IObject obj, System.String value)
        {
            obj.set("author", value);
        }

        public System.String getBody()
        {
            return getBody(this);
        }

        public void setBody(System.String value)
        {
            setBody(this, value);
        }

        public static System.String getBody(DatenMeister.IObject obj)
        {
            var result = obj.get("body", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setBody(DatenMeister.IObject obj, System.String value)
        {
            obj.set("body", value);
        }

    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpSourceFactory", "1.1.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Person : DatenMeister.IObject, DatenMeister.DataProvider.IProxyObject
    {
        private DatenMeister.IObject obj;
        public Person(DatenMeister.IObject obj)
        {
            this.obj = obj;
        }

        public static DatenMeister.IObject create(DatenMeister.IFactory factory)
        {
            return factory.create(ProjektMeister.Data.Entities.AsObject.Types.Person);
        }

        public static Person createTyped(DatenMeister.IFactory factory)
        {
            return new Person(create(factory));
        }

        #region IObject Implementation

        public static DatenMeister.IObject create(DatenMeister.IURIExtent extent)
        {
            var factory = DatenMeister.DataProvider.Factory.GetFor(extent);
            return create(factory); 
        }

        /// <summary>
        /// Gets the property by propertyname. 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Retrieved object</returns>
        public DatenMeister.IObject Value
        {
            get { return this.obj; }
        }

        /// <summary>
        /// Gets the property by propertyname. 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Retrieved object</returns>
        public object get(string propertyName, DatenMeister.RequestType requestType = DatenMeister.RequestType.AsDefault)
        {
            return this.obj.get(propertyName, requestType);
        }

        /// <summary>
        /// Gets all properties as key value pairs
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<DatenMeister.ObjectPropertyPair> getAll()
        {
            return this.obj.getAll();
        }

        /// <summary>
        /// Checks, if a certain property is set
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>true, if set</returns>
        public bool isSet(string propertyName)
        {
            return this.obj.isSet(propertyName);
        }

        /// <summary>
        /// Sets the value of the property 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="value">Value to be set</param>
        public void set(string propertyName, object value)
        {
            this.obj.set(propertyName, value);
        }

        /// <summary>
        /// Unsets the property
        /// </summary>
        /// <param name="propertyName">Name of the property to be removed</param>
        public bool unset(string propertyName)
        {
            return this.obj.unset(propertyName);
        }

        /// <summary>
        /// Deletes this object and all composed elements
        /// </summary>
        public void delete()
        {
            this.obj.delete();
        }

        /// <summary>
        /// Gets the id of the object
        /// </summary>
        public string Id
        {
            get
            {
                return this.obj.Id;
            }
        }

		public DatenMeister.IURIExtent Extent
		{
			get
			{
				return this.obj.Extent;
			}
		}

        #endregion

        public System.String getFirstname()
        {
            return getFirstname(this);
        }

        public void setFirstname(System.String value)
        {
            setFirstname(this, value);
        }

        public static System.String getFirstname(DatenMeister.IObject obj)
        {
            var result = obj.get("firstname", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setFirstname(DatenMeister.IObject obj, System.String value)
        {
            obj.set("firstname", value);
        }

        public System.String getName()
        {
            return getName(this);
        }

        public void setName(System.String value)
        {
            setName(this, value);
        }

        public static System.String getName(DatenMeister.IObject obj)
        {
            var result = obj.get("name", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setName(DatenMeister.IObject obj, System.String value)
        {
            obj.set("name", value);
        }

        public System.String getEmail()
        {
            return getEmail(this);
        }

        public void setEmail(System.String value)
        {
            setEmail(this, value);
        }

        public static System.String getEmail(DatenMeister.IObject obj)
        {
            var result = obj.get("email", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setEmail(DatenMeister.IObject obj, System.String value)
        {
            obj.set("email", value);
        }

        public System.String getPhone()
        {
            return getPhone(this);
        }

        public void setPhone(System.String value)
        {
            setPhone(this, value);
        }

        public static System.String getPhone(DatenMeister.IObject obj)
        {
            var result = obj.get("phone", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setPhone(DatenMeister.IObject obj, System.String value)
        {
            obj.set("phone", value);
        }

        public System.String getTitle()
        {
            return getTitle(this);
        }

        public void setTitle(System.String value)
        {
            setTitle(this, value);
        }

        public static System.String getTitle(DatenMeister.IObject obj)
        {
            var result = obj.get("title", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setTitle(DatenMeister.IObject obj, System.String value)
        {
            obj.set("title", value);
        }

    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpSourceFactory", "1.1.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Task : DatenMeister.IObject, DatenMeister.DataProvider.IProxyObject
    {
        private DatenMeister.IObject obj;
        public Task(DatenMeister.IObject obj)
        {
            this.obj = obj;
        }

        public static DatenMeister.IObject create(DatenMeister.IFactory factory)
        {
            return factory.create(ProjektMeister.Data.Entities.AsObject.Types.Task);
        }

        public static Task createTyped(DatenMeister.IFactory factory)
        {
            return new Task(create(factory));
        }

        #region IObject Implementation

        public static DatenMeister.IObject create(DatenMeister.IURIExtent extent)
        {
            var factory = DatenMeister.DataProvider.Factory.GetFor(extent);
            return create(factory); 
        }

        /// <summary>
        /// Gets the property by propertyname. 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Retrieved object</returns>
        public DatenMeister.IObject Value
        {
            get { return this.obj; }
        }

        /// <summary>
        /// Gets the property by propertyname. 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>Retrieved object</returns>
        public object get(string propertyName, DatenMeister.RequestType requestType = DatenMeister.RequestType.AsDefault)
        {
            return this.obj.get(propertyName, requestType);
        }

        /// <summary>
        /// Gets all properties as key value pairs
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<DatenMeister.ObjectPropertyPair> getAll()
        {
            return this.obj.getAll();
        }

        /// <summary>
        /// Checks, if a certain property is set
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>true, if set</returns>
        public bool isSet(string propertyName)
        {
            return this.obj.isSet(propertyName);
        }

        /// <summary>
        /// Sets the value of the property 
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="value">Value to be set</param>
        public void set(string propertyName, object value)
        {
            this.obj.set(propertyName, value);
        }

        /// <summary>
        /// Unsets the property
        /// </summary>
        /// <param name="propertyName">Name of the property to be removed</param>
        public bool unset(string propertyName)
        {
            return this.obj.unset(propertyName);
        }

        /// <summary>
        /// Deletes this object and all composed elements
        /// </summary>
        public void delete()
        {
            this.obj.delete();
        }

        /// <summary>
        /// Gets the id of the object
        /// </summary>
        public string Id
        {
            get
            {
                return this.obj.Id;
            }
        }

		public DatenMeister.IURIExtent Extent
		{
			get
			{
				return this.obj.Extent;
			}
		}

        #endregion

        public System.String getName()
        {
            return getName(this);
        }

        public void setName(System.String value)
        {
            setName(this, value);
        }

        public static System.String getName(DatenMeister.IObject obj)
        {
            var result = obj.get("name", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setName(DatenMeister.IObject obj, System.String value)
        {
            obj.set("name", value);
        }

        public System.DateTime getStartdate()
        {
            return getStartdate(this);
        }

        public void setStartdate(System.DateTime value)
        {
            setStartdate(this, value);
        }

        public static System.DateTime getStartdate(DatenMeister.IObject obj)
        {
            var result = obj.get("startdate", DatenMeister.RequestType.AsSingle);
            return (result is System.DateTime) ? ((System.DateTime) result) : default(System.DateTime);
        }

        public static void setStartdate(DatenMeister.IObject obj, System.DateTime value)
        {
            obj.set("startdate", value);
        }

        public System.DateTime getEnddate()
        {
            return getEnddate(this);
        }

        public void setEnddate(System.DateTime value)
        {
            setEnddate(this, value);
        }

        public static System.DateTime getEnddate(DatenMeister.IObject obj)
        {
            var result = obj.get("enddate", DatenMeister.RequestType.AsSingle);
            return (result is System.DateTime) ? ((System.DateTime) result) : default(System.DateTime);
        }

        public static void setEnddate(DatenMeister.IObject obj, System.DateTime value)
        {
            obj.set("enddate", value);
        }

        public ProjektMeister.Data.Entities.Person getResponsible()
        {
            return getResponsible(this);
        }

        public void setResponsible(ProjektMeister.Data.Entities.Person value)
        {
            setResponsible(this, value);
        }

        public static ProjektMeister.Data.Entities.Person getResponsible(DatenMeister.IObject obj)
        {
            var result = obj.get("responsible", DatenMeister.RequestType.AsSingle);
            return (result is ProjektMeister.Data.Entities.Person) ? ((ProjektMeister.Data.Entities.Person) result) : default(ProjektMeister.Data.Entities.Person);
        }

        public static void setResponsible(DatenMeister.IObject obj, ProjektMeister.Data.Entities.Person value)
        {
            obj.set("responsible", value);
        }

        public System.Boolean getFinished()
        {
            return getFinished(this);
        }

        public void setFinished(System.Boolean value)
        {
            setFinished(this, value);
        }

        public static System.Boolean getFinished(DatenMeister.IObject obj)
        {
            var result = obj.get("finished", DatenMeister.RequestType.AsSingle);
            return DatenMeister.ObjectConversion.ToBoolean(result);
        }

        public static void setFinished(DatenMeister.IObject obj, System.Boolean value)
        {
            obj.set("finished", value);
        }

        public System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark> getComments()
        {
            return getComments(this);
        }

        public void setComments(System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark> value)
        {
            setComments(this, value);
        }

        public void pushComment(ProjektMeister.Data.Entities.Remark value)
        {
            pushComment(this, value);
        }

        public static System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark> getComments(DatenMeister.IObject obj)
        {
            var result = DatenMeister.Extensions.getAsReflectiveSequence(obj, "comments");
            return (result is System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark>) ? ((System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark>) result) : default(System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark>);
        }

        public static void setComments(DatenMeister.IObject obj, System.Collections.Generic.IEnumerable<ProjektMeister.Data.Entities.Remark> value)
        {
            obj.set("comments", value);
        }

        public static void pushComment(DatenMeister.IObject obj, DatenMeister.IObject value)
        {
            var list = DatenMeister.Extensions.getAsReflectiveSequence(obj, "comments");
            list.Add(value);
        }

        public static void pushComment(DatenMeister.IObject obj, ProjektMeister.Data.Entities.Remark value)
        {
            var list = DatenMeister.Extensions.getAsReflectiveSequence(obj, "comments");
            list.Add(value);
        }

    }

}
