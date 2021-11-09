using System;
using FluentAssertions;
using System.Text.Json;
using FluentAssertions.Execution;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class DeserializeWithSystemTest
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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // when
            var result = JsonSerializer.Deserialize<EmployeeDto?>(json, options);
            // then
            using (new AssertionScope())
            {
                // sadly all of this is true
                result.Should().NotBeNull();
                result!.Id.Should().Be("1");   
                result!.Name.Should().Be("Alex");   
                result!.Email.Should().BeNull();   
            }
        }
        
        [Fact(DisplayName="Should not deserialize because email type is wrong")]
        public void ShouldNotDeserializeBecauseTypesAreWrong()
        {
            // given
            var json = @"
            {
                ""id"": ""1"",
                ""name"": ""Alex"",
                ""email"": -1
            }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // when
            Action act = () => JsonSerializer.Deserialize<EmployeeDto?>(json, options);
            // then
            act.Should().Throw<JsonException>();
        }
        
        [Fact(DisplayName="Should not deserialize because no required elements are present but sadly does")]
        public void ShouldNotDeserialize()
        {
            // given
            var json = @"
            {
                ""foo"": ""bar""
            }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // when
            var result = JsonSerializer.Deserialize<EmployeeDto?>(json, options);
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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // when
            var result = JsonSerializer.Deserialize<EmployeeDto?>(json, options);
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