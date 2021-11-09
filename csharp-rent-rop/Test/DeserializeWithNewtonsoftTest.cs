using System;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class DeserializeWithNewtonsoftTest
    {
        [Fact(DisplayName="Should deserialize because all required fields are present")]
        public void ShouldDeserialize()
        {
            // given
            var json = @"
            {
                ""id"": ""1"",
                ""name"": ""Alex""
            }";
            var settings = new JsonSerializerSettings
            {
            };
            // when
            var result = JsonConvert.DeserializeObject<EmployeeDto?>(json, settings);
            // then
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result!.Id.Should().Be("1");   
                result!.Name.Should().Be("Alex");   
                result!.Email.Should().BeNull();   
            }
        }
        
        [Fact(DisplayName="Should deserialize because email can be converted from number to string")]
        public void ShouldDeserializeBecauseTypesCanBeConverted()
        {
            // given
            var json = @"
            {
                ""id"": ""1"",
                ""name"": ""Alex"",
                ""email"": -1
            }";
            var settings = new JsonSerializerSettings
            {
            };
            // when
            var result = JsonConvert.DeserializeObject<EmployeeDto?>(json, settings);
            // then
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result!.Id.Should().Be("1");   
                result!.Name.Should().Be("Alex");   
                result!.Email.Should().Be("-1");   
            }
        }
        
        [Fact(DisplayName="Should not deserialize because no required elements are present but sadly does")]
        public void ShouldNotDeserialize()
        {
            // given
            var json = @"
            {
                ""foo"": ""bar""
            }";
            var settings = new JsonSerializerSettings
            {
            };
            // when
            var result = JsonConvert.DeserializeObject<EmployeeDto?>(json, settings);
            // then
            using (new AssertionScope())
            {
                // sadly all of this is true
                result.Should().NotBeNull();
                result!.Id.Should().BeNull();   
                result!.Name.Should().BeNull();   
                result!.Email.Should().BeNull();   
            }
        }
        
        [Fact(DisplayName="Should stilll not deserialize because only id is present but sadly does")]
        public void StillShouldNotDeserialize()
        {
            // given
            var json = @"
            {
                ""id"": ""1""
            }";
            var settings = new JsonSerializerSettings
            {

            };
            // when
            var result = JsonConvert.DeserializeObject<EmployeeDto?>(json, settings);
            // then
            using (new AssertionScope())
            {
                // sadly all of this is true
                result.Should().NotBeNull();
                result!.Id.Should().Be("1");   
                result!.Name.Should().BeNull();   
                result!.Email.Should().BeNull();   
            }
        }
    }
}