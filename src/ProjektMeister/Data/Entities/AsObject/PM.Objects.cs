namespace ProjektMeister.Data.Entities.AsObject
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpSourceFactory", "1.0.6.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Comment : DatenMeister.IObject, DatenMeister.DataProvider.IProxyObject
    {
        private DatenMeister.IObject obj;
        public Comment(DatenMeister.IObject obj)
        {
            this.obj = obj;
        }

        public static DatenMeister.IObject create(DatenMeister.IFactory factory)
        {
            return factory.create(ProjektMeister.Data.Entities.AsObject.Types.Comment);
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
        public object get(string propertyName)
        {
            return this.obj.get(propertyName);
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("created"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("author"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("body"));
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setBody(DatenMeister.IObject obj, System.String value)
        {
            obj.set("body", value);
        }

    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpSourceFactory", "1.0.6.0")]
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
        public object get(string propertyName)
        {
            return this.obj.get(propertyName);
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("name"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("email"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("phone"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("title"));
            return DatenMeister.ObjectConversion.ToString(result);
        }

        public static void setTitle(DatenMeister.IObject obj, System.String value)
        {
            obj.set("title", value);
        }

    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DatenMeister.Logic.SourceFactory.CSharpSourceFactory", "1.0.6.0")]
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
        public object get(string propertyName)
        {
            return this.obj.get(propertyName);
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("name"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("startdate"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("enddate"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("responsible"));
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
            var result = DatenMeister.Extensions.AsSingle(obj.get("finished"));
            return DatenMeister.ObjectConversion.ToBoolean(result);
        }

        public static void setFinished(DatenMeister.IObject obj, System.Boolean value)
        {
            obj.set("finished", value);
        }

    }

}
