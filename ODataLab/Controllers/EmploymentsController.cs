﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ODataLab.Models;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Microsoft.Data.OData.Query.SemanticAst;


namespace ODataLab.Controllers
{
 
    public class FilterValue
    {
        public string ComparisonOperator { get; set; }
        public string Value { get; set; }
        public string FieldName { get; set; }
        public string LogicalOperator { get; set; }
    }

    public class MyFilterValueSupplier<TSource> : QueryNodeVisitor<TSource>
        where TSource: class
    {
        List<FilterValue> filterValueList = new List<FilterValue>();
        FilterValue current = new FilterValue();

        public override TSource Visit(BinaryOperatorNode nodeIn)
        {
            if(nodeIn.OperatorKind == Microsoft.Data.OData.Query.BinaryOperatorKind.And 
                || nodeIn.OperatorKind == Microsoft.Data.OData.Query.BinaryOperatorKind.Or)
            {
                current.LogicalOperator = nodeIn.OperatorKind.ToString();
            }
            else
            {
                current.ComparisonOperator = nodeIn.OperatorKind.ToString();
            }
            nodeIn.Right.Accept(this);
            nodeIn.Left.Accept(this);
            return current as TSource;
        }
        public override TSource Visit(SingleValuePropertyAccessNode nodeIn)
        {
            current.FieldName = nodeIn.Property.Name;
            //We are finished, add current to collection.
            filterValueList.Add(current);
            //Reset current
            current = new FilterValue();
            return current as TSource;
        }

        public override TSource Visit(ConstantNode nodeIn)
        {
            current.Value = nodeIn.LiteralText;
            return current as TSource;
        }

        public override TSource Visit(AllNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Source.Kind.ToString() };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        public override TSource Visit(AnyNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Source.Kind.ToString()};
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        public override TSource Visit(CollectionFunctionCallNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Name };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        

        public override TSource Visit(CollectionNavigationNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Kind.ToString() };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }
        public override TSource Visit(CollectionPropertyAccessNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Property.Name };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        public override TSource Visit(ConvertNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Source.TypeReference.ToString() };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        public override TSource Visit(EntityCollectionCastNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Kind.ToString() };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        public override TSource Visit(SingleValueOpenPropertyAccessNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Name};
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }

        public override TSource Visit(SingleEntityCastNode nodeIn)
        {
            FilterValue filterValue = new FilterValue { FieldName = nodeIn.Kind.ToString() };
            filterValueList.Add(filterValue);
            return filterValue as TSource;
        }
    }

    public class EmploymentsController : ODataController
    {
        public EmploymentsController()
        {
            dataBaseMock = new List<EmploymentFieldValueModel>();
            dataBaseMock.Add(new EmploymentFieldValueModel { FieldName = "IBAN", FieldType = "String" });
            dataBaseMock.Add(new EmploymentFieldValueModel { FieldName = "Other", FieldType = "int" });

            stringMock = new List<string>();
            stringMock.Add("IBAN");
            stringMock.Add("OTher");
        }
        private List<EmploymentFieldValueModel> dataBaseMock;
        private List<string> stringMock;
        private EmploymentContext db = new EmploymentContext();

        // GET: api/Employments
        [EnableQuery]
        public IQueryable<ReturnModel> GetEmployments(ODataQueryOptions<ReturnModel> options)
        {
            
            var result = (from emp in db.Employments
                         join person in db.People on emp.person.Id equals person.Id into Collection
                         select new ReturnModel
                         {
                             FirstName = emp.Name
                         });
            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var t = result.ToList();

            return t.AsQueryable();
        }

        
        // GET: api/Employments1/5
        [ResponseType(typeof(Employment))]
        public async Task<IHttpActionResult> GetEmployment(Guid id)
        {
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }

            return Ok(employment);
        }

       

        // POST: api/Employments1
        [ResponseType(typeof(Employment))]
        public async Task<IHttpActionResult> Post( Employment employment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = new Person();
            person.FirstName = "What ever";
            person.LastName = "Some at random";
            employment.person = person;
            db.Employments.Add(employment);
            await db.SaveChangesAsync();

            return Created(employment);
        }

        // DELETE: api/Employments1/5
        [ResponseType(typeof(Employment))]
        public async Task<IHttpActionResult> DeleteEmployment(Guid id)
        {
            Employment employment = await db.Employments.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }

            db.Employments.Remove(employment);
            await db.SaveChangesAsync();

            return Ok(employment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}